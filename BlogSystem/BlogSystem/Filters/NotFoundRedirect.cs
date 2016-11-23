using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.Filters
{
    public class NotFoundRedirect : ActionFilterAttribute, IExceptionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Cookies.Add(new HttpCookie("mvc", "Gosho"));
            base.OnActionExecuting(filterContext);
        }

        // on every exception --- FOR exceptions in ACTIONS handler
        public void OnException(ExceptionContext filterContext)
        {
            throw new NotImplementedException();
        }
    }
}