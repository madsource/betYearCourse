using ProjectsTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsTracker.Services.Contracts
{
    public interface IUsersService : IService<ApplicationUser>
    {
        IQueryable<ApplicationUser> GetAll();
        List<string> GetUserRoles(string userId);
        void AddRoleToUser(string userId, string role);
        void RemoveRoleFromUser(string userId, string role);
    }
}
