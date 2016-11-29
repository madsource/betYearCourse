using ProjectsTracker.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectsTracker.Models;
using ProjectsTracker.Data;

namespace ProjectsTracker.Services
{
    public class UsersService :BaseService<ApplicationUser>, IUsersService
    {
        public UsersService(IProjectsTrackerData data)
            :base(data)
        {
        }

    }
}
