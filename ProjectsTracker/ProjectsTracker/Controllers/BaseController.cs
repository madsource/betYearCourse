using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectsTracker.Data;

namespace ProjectsTracker.Controllers
{
    public class BaseController : Controller
    {
        protected ProjectsTrackerDbContext ProjectsTrackerDbContext { get; private set; }
        public BaseController()
        {
            this.ProjectsTrackerDbContext = new ProjectsTrackerDbContext();
        }
    }
}