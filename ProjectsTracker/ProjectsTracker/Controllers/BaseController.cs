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
        protected static object ProjectId; 
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {          

            base.OnActionExecuting(filterContext);
        }
    }
}