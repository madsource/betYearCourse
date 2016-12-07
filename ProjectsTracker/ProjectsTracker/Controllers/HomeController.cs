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
using Microsoft.AspNet.Identity;
using PagedList;

namespace ProjectsTracker.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private IProjectService projectService;
        private int itemsPerPage;

        public HomeController(IProjectService projectService)
        {
            this.projectService = projectService;
            this.itemsPerPage = PtConstants.itemsPerPage;
        }

        public ActionResult Index(string search, int? page)
        {
            var projects = this.GetActiveProjects(search);
            int pageNumber = page ?? 1;

            var pagedProjects = projects.ToPagedList(pageNumber, this.itemsPerPage);

            HomeViewModel homeVm = new HomeViewModel(pagedProjects);

            if(Request.IsAjaxRequest() && search != null)
            {
                return PartialView("_ProjectsList", homeVm.Projects);
            }           
       
            return View(homeVm);
        }

        public ActionResult MyProjects(string search, int? page)
        {
            var projects = this.GetActiveProjects(search).Where(p => p.Owner.Id == User.Identity.GetUserId()).ToList();

            int pageNumber = page ?? 1;

            var pagedProjects = projects.ToPagedList(pageNumber, this.itemsPerPage);

            HomeViewModel homeVm = new HomeViewModel(pagedProjects);

            if (Request.IsAjaxRequest() && search != null)
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