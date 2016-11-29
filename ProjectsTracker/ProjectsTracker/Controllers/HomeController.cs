using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectsTracker.Data;
using ProjectsTracker.Models;
using ProjectsTracker.Services.Contracts;
using ProjectsTracker.ViewModels;

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
            IEnumerable<ProjectViewModel> projects = this.projectService.GetAll().Select(p => new ProjectViewModel()
            {
                CreatedOn = p.CreatedOn,
                ExpectedEndDate = p.ExpectedEndDate,
                ClientName = p.ClientName,
                Content = p.Content,
                DateFinished = p.DateFinished,
                EstimatedBudget = p.EstimatedBudget,
                Id = p.Id,
                isActive = p.isActive,
                IsDeleted = p.IsDeleted,
                OwnerName = p.Owner.FirstName + p.Owner.LastName,
                OwnerId = p.Owner.Id,
                Title = p.Title
            }).OrderByDescending(p => p.CreatedOn).ToList();


            return View(projects);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}