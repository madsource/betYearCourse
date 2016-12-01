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
        public ActionResult Index()
        {        
            IEnumerable<ProjectViewModel> projects = this.projectService.GetAll()
                .OrderByDescending(p => p.CreatedOn)
                .ProjectTo<ProjectViewModel>()
                .ToList();

            IEnumerable<Project> projectsDb = projects.AsQueryable().ProjectTo<Project>().ToList();   

            return View(projects);
        }
    }
}