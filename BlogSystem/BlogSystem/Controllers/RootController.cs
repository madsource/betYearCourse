using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogSystem.Data;
using BlogSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlogSystem.Controllers
{
    public class RootController : Controller
    {
        protected BlogSystemDbContext BlogSystemDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager;
        public RootController()
        {
            this.BlogSystemDbContext = new BlogSystemDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.BlogSystemDbContext));
        }
    }
}