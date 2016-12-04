using Microsoft.AspNet.Identity;
using ProjectsTracker.Common;
using ProjectsTracker.Models;
using ProjectsTracker.Services.Contracts;
using ProjectsTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace ProjectsTracker.Controllers
{
    [Authorize]
    public class PTaskController : Controller
    {

        private IUsersService userService;
        private IPTaskService ptaskService;
        private IProjectService projectService;

        public PTaskController(IUsersService userService, IPTaskService ptaskService, IProjectService projectService)
        {
            this.userService = userService;
            this.ptaskService = ptaskService;
            this.projectService = projectService;
        }
             

        public ActionResult Index()
        {

            PTaskViewModel ptaskVM = new PTaskViewModel();
            return View(ptaskVM);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            PTaskViewModel ptaskVM = new PTaskViewModel();
            return View(ptaskVM);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.AdmminRole +","+ RoleConstants.ManagerRole)]
        public ActionResult Create(PTaskViewModel pTaskVm, int projectId)
        {
            Project project = this.projectService.Find(projectId);

            if(project == null)
            {
                return HttpNotFound();
            }

            if(project.Owner.Id != User.Identity.GetUserId())
            {
                return new HttpUnauthorizedResult();
            }

            PTask pTask = Mapper.Map<PTask>(pTaskVm);

            ProjectViewModel updatedProject = Mapper.Map<ProjectViewModel>(this.projectService.AddTask(project, pTask));

            if(Request.IsAjaxRequest())
            {

                return PartialView("_TasksList", updatedProject.Tasks);
            }
            else
            {
                return RedirectToAction("Details", "Project", updatedProject);
            }
        }

        // GET: PTask/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PTask/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PTask/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PTask/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
