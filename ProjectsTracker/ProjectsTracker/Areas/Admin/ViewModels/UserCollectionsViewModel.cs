using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectsTracker.ViewModels;

namespace ProjectsTracker.Areas.Admin.ViewModels
{
    public class UserCollectionsViewModel
    {
        public UserCollectionsViewModel()
        {
            this.Users = new List<ApplicationUserViewModel>();
            this.ManagerUsers = new List<ApplicationUserViewModel>();
        }
        public IEnumerable<ApplicationUserViewModel> ManagerUsers { get; set; }
        public IEnumerable<ApplicationUserViewModel> Users { get; set; }
    }
}