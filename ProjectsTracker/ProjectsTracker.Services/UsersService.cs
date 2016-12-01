using ProjectsTracker.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectsTracker.Models;
using ProjectsTracker.Data;

namespace ProjectsTracker.Services
{
    public class UsersService : BaseService<ApplicationUser>, IUsersService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersService(IProjectsTrackerData data)
            : base(data)
        {
            _userManager =
                new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ProjectsTrackerDbContext()));
        }


        public List<string> GetUserRoles(string userId)
        {
            var roles = this._userManager.GetRoles(userId);
            return roles as List<string>;
        }

        public void AddRoleToUser(string userId, string role)
        {
            this._userManager.AddToRole(userId, role);
        }

        public void RemoveRoleFromUser(string userId, string role)
        {           
            this._userManager.RemoveFromRole(userId, role);
        }
    }
}
