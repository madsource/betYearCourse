using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectsTracker.Data;
using ProjectsTracker.Models;
using ProjectsTracker.Services.Contracts;
using ProjectsTracker.ViewModels;
using AutoMapper.QueryableExtensions;
using Microsoft.Ajax.Utilities;

namespace ProjectsTracker.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private IProjectService projectService; 


        public HomeController(IProjectService projectService)
        {
            this.projectService = projectService;
        }
        public ActionResult Index(string search)
        {
            //IEnumerable<ProjectViewModel> projects = this.projectService.GetAll().Select(p => new ProjectViewModel()
            //{
            //    CreatedOn = p.CreatedOn,
            //    ExpectedEndDate = p.ExpectedEndDate,
            //    ClientName = p.ClientName,
            //    Content = p.Content,
            //    DateFinished = p.DateFinished,
            //    EstimatedBudget = p.EstimatedBudget,
            //    Id = p.Id,
            //    isActive = p.isActive,
            //    IsDeleted = p.IsDeleted,
            //    OwnerName = p.Owner.FirstName + p.Owner.LastName,
            //    OwnerId = p.Owner.Id,
            //    Title = p.Title
            //}).OrderByDescending(p => p.CreatedOn).ToList();

            var projectsInDb = this.projectService.GetAll();

            IEnumerable<ProjectViewModel> projects = projectsInDb
                .OrderByDescending(p => p.CreatedOn)
                .ProjectTo<ProjectViewModel>()
                .ToList();

            //IEnumerable<Project> projectsDb = projects.AsQueryable().ProjectTo<Project>().ToList();

            if (Request.IsAjaxRequest() && search != null)
            {
                var filteredDbProjects = projectsInDb.Where(p => p.Title.Contains(search) ||
                                    p.Content.Contains(search) ||
                                    p.ClientName.Contains(search) ||
                                    (p.Owner.FirstName + p.Owner.LastName).Contains(search));

                IEnumerable<ProjectViewModel> filteredProjects = filteredDbProjects
                .OrderByDescending(p => p.CreatedOn)
                .ProjectTo<ProjectViewModel>()
                .ToList();

                return PartialView("_ProjectsList", filteredProjects);
            }

            return View(projects);
        }
    }
}