using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectsTracker.ViewModels
{
    public class ApplicationUserViewModel
    {
        public ApplicationUserViewModel()
        {
            this.userRoles = new HashSet<string>();
        }

        public string Id { get; set; }

        [Display(Name = "User")]
        public string UserName { get; set; }

        public string Email { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string RoleId { get; set; }

        public ICollection<string> userRoles { get; set; }
    }
}