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
using System.Net;

namespace ProjectsTracker.Controllers
{
    [Authorize]
    public class PTaskController : Controller
    {

        private IUsersService usersService;
        private IPTaskService ptaskService;
        private IProjectService projectService;

        public PTaskController(IUsersService usersService, IPTaskService ptaskService, IProjectService projectService)
        {
            this.usersService = usersService;
            this.ptaskService = ptaskService;
            this.projectService = projectService;
        }
             

        public ActionResult Index()
        {

            PTaskViewModel ptaskVM = new PTaskViewModel();
            return View(ptaskVM);
        }

        public ActionResult Details(int? Id)
        {
            if(Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PTaskViewModel taskVm = Mapper.Map<PTaskViewModel>(ptaskService.Find(Id));

            if(taskVm == null)
            {
                return HttpNotFound();
            }

            return View(taskVm);
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

            if(project.Owner.Id != User.Identity.GetUserId() && User.IsInRole(RoleConstants.ManagerRole))
            {
                return new HttpUnauthorizedResult();
            }

            PTask pTask = Mapper.Map<PTask>(pTaskVm);

            //pTask.CreatedOn = DateTime.Now;

            //set users of task
            ApplicationUser currentUser = this.usersService.Find(User.Identity.GetUserId());
            ApplicationUser chosenOwner = this.usersService.Find(pTaskVm.OwnerId);

            pTask.Author = currentUser;
            pTask.Owner = chosenOwner;

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

        [HttpGet]
        public ActionResult Update(int? Id, int? taskNumber)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (taskNumber != null)
            {
                ViewData["counter"] = taskNumber;
            }

            PTaskViewModel taskVm = Mapper.Map<PTaskViewModel>(ptaskService.Find(Id));

            if (taskVm == null)
            {
                return HttpNotFound();
            }

            ViewData["Users"] = new SelectList(this.usersService.GetAll().Where(u => u.UserName != PtConstants.AdminUsername).ToList(), "Id", "UserName", taskVm.OwnerId);

            return PartialView("_UpdateTask", taskVm);
        }

        [HttpPost]
        public ActionResult Update(PTaskViewModel pTaskVm, int? taskNumber)
        {
            if (taskNumber != null)
            {
                ViewData["counter"] = taskNumber;
            }

            if (ModelState.IsValid)
            {
                PTask pTask = Mapper.Map<PTask>(pTaskVm);
                this.ptaskService.Update(pTask);

                PTaskViewModel updatedTaskVm = Mapper.Map<PTaskViewModel>(ptaskService.Find(pTaskVm.Id));
                
                if (Request.IsAjaxRequest())
                {
                    Response.StatusCode = (int)HttpStatusCode.OK;                   
                    
                    return PartialView("_Task", updatedTaskVm);
                }
            }            

            ViewData["Users"] = new SelectList(this.usersService.GetAll().Where(u => u.UserName != PtConstants.AdminUsername).ToList(), "Id", "UserName", pTaskVm.OwnerId);

            return PartialView("_Task", pTaskVm);            
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.AdmminRole + "," + RoleConstants.ManagerRole)]
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PTask task = ptaskService.Find(Id);
            return View("Details", task);
        }


        [HttpPost]
        [Authorize(Roles = RoleConstants.AdmminRole + "," + RoleConstants.ManagerRole)]
        [ActionName("Delete")]
        public ActionResult DeleteTask(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PTask task = ptaskService.Find(Id);

            if (task == null)
            {
                return HttpNotFound();
            }

            ptaskService.Delete(task.Id);

            IEnumerable<PTaskViewModel> tasks = ptaskService.GetAll()
                .ProjectTo<PTaskViewModel>()
                .ToList();
           
            return PartialView("_TasksList", tasks);           
        }
    }
}
