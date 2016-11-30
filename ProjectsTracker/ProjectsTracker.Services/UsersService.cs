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
        public UsersService(IProjectsTrackerData data)
            : base(data)
        {

        }


        public List<string> GetUserRoles(string userId)
        {
            using (var userManager =
                    new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ProjectsTrackerDbContext())))
            {
                var roles = userManager.GetRoles(userId);
                return roles as List<string>;
            }
        }
    }
}
