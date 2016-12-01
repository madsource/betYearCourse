using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectsTracker.Services.Contracts;
using ProjectsTracker.ViewModels;
using AutoMapper.QueryableExtensions;
using Microsoft.Owin.Security.Provider;
using ProjectsTracker.Areas.Admin.ViewModels;
using WebGrease.Css.Extensions;

namespace ProjectsTracker.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private IUsersService usersService;

        public UsersController( IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public ActionResult Index()
        {
            IEnumerable<ApplicationUserViewModel> users = usersService.GetAll()
                .ProjectTo<ApplicationUserViewModel>();

            var usersWithRoles = users?.Select(u =>
            {
                u.userRoles = usersService.GetUserRoles(u.Id);
                return u;
            }).ToList();

            return View(usersWithRoles);
        }

        public ActionResult AddUserToRole(string userId, string role)
        {
            this.usersService.AddRoleToUser(userId, role);
            return RedirectToAction("Index");
        }

        public ActionResult RemoveUserFromRole(string userId, string role)
        {
            this.usersService.RemoveRoleFromUser(userId, role);
            return RedirectToAction("Index");
        }
    }
}