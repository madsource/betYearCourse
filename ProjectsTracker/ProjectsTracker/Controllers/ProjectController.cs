﻿using System;
using System.Data.Entity.Infrastructure.Annotations;
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
        public ActionResult Details(int Id)
        {
            ProjectViewModel projectVm = Mapper.Map<ProjectViewModel>(projectService.Find(Id));
            return View(projectVm);
        }
    }
}