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

            //var managerRole = usersService.GetAll()
            //    .Where(u => u.Roles.Select(x => x.UserId).Contains(Common.RoleConstants.ManagerRole));
            //var adminRole = usersService.GetAll()
            //    .Where(u => u.Roles.Select(x => x.UserId).Contains(Common.RoleConstants.AdmminRole));

            //IEnumerable<ApplicationUserViewModel> normalUsers = usersService.GetAll()
            //    .Except(managerRole).Except(adminRole)
            //    .ProjectTo<ApplicationUserViewModel>();

            //UserCollectionsViewModel usersCollections = new UserCollectionsViewModel();
            //usersCollections.ManagerUsers = managerUsers;
            //usersCollections.Users = normalUsers;

            var usersWithRoles = users?.Select(u =>
            {
                u.userRoles = usersService.GetUserRoles(u.Id);
                return u;
            }).ToList();

            return View(usersWithRoles);
        }

        public ActionResult Create()
        {
            throw new System.NotImplementedException();
        }
    }
}