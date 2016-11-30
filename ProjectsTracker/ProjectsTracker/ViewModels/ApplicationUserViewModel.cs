using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectsTracker.ViewModels
{
    public class ApplicationUserViewModel
    {
        public ApplicationUserViewModel()
        {
            this.userRoles = new List<string>();
        }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RoleId { get; set; }
        public ICollection<string> userRoles { get; set; }
    }
}