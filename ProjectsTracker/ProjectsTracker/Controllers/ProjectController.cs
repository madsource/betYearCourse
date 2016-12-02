using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using ProjectsTracker.Models;
using ProjectsTracker.ViewModels;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.Identity;
using ProjectsTracker.Common;
using ProjectsTracker.Services;
using ProjectsTracker.Services.Contracts;

namespace ProjectsTracker.Controllers
{
    [Authorize(Roles = RoleConstants.AdmminRole +"," + RoleConstants.ManagerRole)]
    public class ProjectController : Controller
    {
        private IProjectService projectService;
        private IUsersService usersService;

        public ProjectController(IProjectService projectService, IUsersService usersService)
        {
            this.projectService = projectService;
            this.usersService = usersService;
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectViewModel projectViewModel)
        {
            Project project = Mapper.Map<Project>(projectViewModel);
            ApplicationUser currentUser = usersService.Find(User.Identity.GetUserId());
            project.Owner = currentUser;

            this.projectService.Add(project);

            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var project = projectService.Find(Id);
            if (project == null)
            {
                return HttpNotFound();
            }

            if (project.Owner.Id != User.Identity.GetUserId())
            {
                return new HttpUnauthorizedResult();
            }

            ProjectViewModel projectViewModel = Mapper.Map<ProjectViewModel>(project);
            return View(projectViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProjectViewModel projectViewModel)
        {
            if (ModelState.IsValid)
            {
                Project project = Mapper.Map<Project>(projectViewModel);
                project.CreatedOn = DateTime.Now;
                projectService.Update(project);
                return RedirectToAction("Index", "Home");
            }

            return View(projectViewModel);
        }


        [HttpPost]
        [Authorize(Roles = RoleConstants.AdmminRole)]
        public ActionResult Delete(int? projectId)
        {
            if (projectId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Project project = projectService.Find(projectId);
            project.IsDeleted = true;
            projectService.Update(project);

            // projectService.Delete(Id);

            IEnumerable <ProjectViewModel> projects = projectService.GetAll()
                .OrderByDescending(p => p.CreatedOn)
                .ProjectTo<ProjectViewModel>()
                .ToList();

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ProjectsList", projects);
            }
            else
            {
                return RedirectToAction("Index", "Home", projects);
            }
        }


        [HttpGet]
        public ActionResult Details(int Id)
        {
            ProjectViewModel projectVm = Mapper.Map<ProjectViewModel>(projectService.Find(Id));
            return View(projectVm);
        }
    }
}