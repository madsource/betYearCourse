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
    [Authorize]
    public class ProjectController : BaseController
    {
        private IProjectService projectService;
        private IUsersService usersService;
        private IStatisticsService statisticsService;

        public ProjectController(IProjectService projectService, IUsersService usersService, IStatisticsService statisticsService)
        {
            this.projectService = projectService;
            this.usersService = usersService;
            this.statisticsService = statisticsService;
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleConstants.AdmminRole + "," + RoleConstants.ManagerRole)]
        public ActionResult Create(ProjectViewModel projectViewModel)
        {
            Project project = Mapper.Map<Project>(projectViewModel);
            ApplicationUser currentUser = usersService.Find(User.Identity.GetUserId());
            project.Owner = currentUser;

            this.projectService.Add(project);

            return RedirectToAction("Index","Home", new { mine = "true" });
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.AdmminRole + "," + RoleConstants.ManagerRole)]
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

            if ((project.Owner.Id != User.Identity.GetUserId()) && !User.IsInRole(RoleConstants.AdmminRole) )
            {
                return new HttpUnauthorizedResult();
            }

            ProjectViewModel projectViewModel = Mapper.Map<ProjectViewModel>(project);
            return View(projectViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleConstants.AdmminRole + "," + RoleConstants.ManagerRole)]
        public ActionResult Edit(ProjectViewModel projectViewModel)
        {
            if (ModelState.IsValid)
            {
                Project project = Mapper.Map<Project>(projectViewModel);
                projectService.Update(project);
                return RedirectToAction("Index", "Home");
            }

            return View(projectViewModel);
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.AdmminRole + "," + RoleConstants.ManagerRole)]
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Project project = projectService.Find(Id);
            return View("Details", project);
        }


        [HttpPost]
        [Authorize(Roles = RoleConstants.AdmminRole)]
        [ActionName("Delete")]
        public ActionResult DeleteProject(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Project project = projectService.Find(Id);

            if (project == null)
            {
                return HttpNotFound();
            }

            projectService.SoftDelete(project);

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
        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProjectViewModel projectVm = Mapper.Map<ProjectViewModel>(projectService.Find(Id));

            if(projectVm == null)
            {
                return HttpNotFound();
            }

            Project project = Mapper.Map<Project>(projectVm);

            projectVm.TotalTimeSpend = this.statisticsService.GetProjectTotalTimeSpend(project);
            projectVm.Status = this.statisticsService.GetProjectStatus(project);
            projectVm.Users = new SelectList(this.usersService.GetAll().Where(u => u.UserName != PtConstants.AdminUsername).ToList(), "Id", "UserName");

            ProjectId = projectVm.Id;
            return View(projectVm);
        }
    }
}