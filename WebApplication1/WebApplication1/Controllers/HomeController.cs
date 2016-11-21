using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EfDemo.Data;
using EfDemo.Models;

namespace EfDemo.Controllers
{
    public class HomeController : Controller
    {
        EfDBContext dbContext;

        
        public HomeController()
        {
            dbContext = new EfDBContext();
        }

        [Authorize]
        public ActionResult Index()
        {
            var posts = dbContext.Posts.ToList();
            return View(posts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}