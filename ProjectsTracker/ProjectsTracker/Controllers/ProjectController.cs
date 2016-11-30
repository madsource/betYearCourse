using System.Data.Entity.Infrastructure.Annotations;
using System.Web.Mvc;
using AutoMapper;
using ProjectsTracker.Models;
using ProjectsTracker.ViewModels;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.Identity;
using ProjectsTracker.Services;
using ProjectsTracker.Services.Contracts;

namespace ProjectsTracker.Controllers
{
    [Authorize]
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
        public ActionResult Create(ProjectViewModel projectViewModel)
        {
            Project project = Mapper.Map<Project>(projectViewModel);
            ApplicationUser currentUser = usersService.Find(User.Identity.GetUserId());
            project.Owner = currentUser;

            this.projectService.Add(project);

            return RedirectToAction("Index","Home");
        }
    }
}