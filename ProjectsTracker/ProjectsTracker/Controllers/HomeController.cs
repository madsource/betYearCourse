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
using AutoMapper;

namespace ProjectsTracker.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private IProjectService projectService;
        private IStatisticsService statisticsService;
        private IUsersService usersService;
        private int itemsPerPage;
        private IDictionary<string, double> statistics;

        public HomeController(IProjectService projectService, IStatisticsService statisticsService, IUsersService usersService)
        {
            this.projectService = projectService;
            this.statisticsService = statisticsService;
            this.itemsPerPage = PtConstants.itemsPerPage;
        }

        public ActionResult Index(string search, int? page, string mine)
        {
            var projects = this.GetActiveProjects(search);
            
            if(mine == "true")
            {
                projects = projects.Where(p => p.Owner.Id == User.Identity.GetUserId()).ToList();
            }

            int pageNumber = page ?? 1;
            var pagedProjects = projects.ToPagedList(pageNumber, this.itemsPerPage);

            if (this.statistics == null)
            {
                this.statistics = this.statisticsService.GetStatisticsForProjects();
            }

            HomeViewModel homeVm = new HomeViewModel(pagedProjects, this.statistics);

            if (Request.IsAjaxRequest() && search != null)
            {
                return PartialView("_ProjectsList", homeVm.Projects);
            }

            if(mine == "true")
            {
                return View("MyProjects", homeVm);
            }

            return View(homeVm);
        }

        private List<ProjectViewModel> GetActiveProjects(string search)
        {
            var projectsInDb = this.projectService.GetAll();

            List<ProjectViewModel> projects = this.ConvertDbToVmList(projectsInDb);

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

        private List<ProjectViewModel> ConvertDbToVmList(IQueryable<Project> projects)
        {
            return projects.OrderByDescending(p => p.CreatedOn)
                .ProjectTo<ProjectViewModel>()
                .ToList()
                .Select(p =>
                {
                    p.Progress = ((p.Tasks.Any()) ? p.Tasks.Sum(t => t.ProgressPercent) / p.Tasks.Count : 0);
                    p.WorkingUsers = this.GetVmUsersList(this.statisticsService.GetProjectUsers(this.GetProject(p)));
                    p.Status = this.statisticsService.GetProjectStatus(this.GetProject(p));
                    return p;
                })
                .ToList();
        }

        private Project GetProject(ProjectViewModel projectVm)
        {
            var project = Mapper.Map<Project>(projectVm);
            return project;
        }

        private ICollection<ApplicationUserViewModel> GetVmUsersList(ICollection<ApplicationUser> users)
        {
            return users
                .AsQueryable()
                .ProjectTo<ApplicationUserViewModel>()
                .ToList();
        }
    }
}

