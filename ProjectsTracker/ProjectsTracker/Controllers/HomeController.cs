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
using ProjectsTracker.Common;

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
            var projects = this.GetActiveProjects(search);

            HomeViewModel homeVm = new HomeViewModel(projects);

            if(Request.IsAjaxRequest() && search != null)
            {
                return PartialView("_ProjectsList", homeVm.Projects);
            }

            return View(homeVm);
        }

        private List<ProjectViewModel> GetActiveProjects(string search)
        {
            var projectsInDb = this.projectService.GetAll();

            List<ProjectViewModel> projects = this.ConvertDbToVmList(projectsInDb).ToList();

            if (search != null)
            {
                var filteredDbProjects = projectsInDb.Where(p => p.Title.Contains(search) ||
                                    p.Content.Contains(search) ||
                                    p.ClientName.Contains(search) ||
                                    (p.Owner.FirstName + p.Owner.LastName).Contains(search));

                List<ProjectViewModel> filteredProjects = this.ConvertDbToVmList(filteredDbProjects).ToList();

                return filteredProjects;
            }

            return projects;
        }

        private IEnumerable<ProjectViewModel> ConvertDbToVmList(IQueryable<Project> projects)
        {
            return projects.OrderByDescending(p => p.CreatedOn)
                .ProjectTo<ProjectViewModel>()
                .ToList()
                .Select(p => { p.Progress = ((p.Tasks.Any()) ? p.Tasks.Sum(t => t.ProgressPercent) / p.Tasks.Count : 0); return p; });                
        }

    }
}