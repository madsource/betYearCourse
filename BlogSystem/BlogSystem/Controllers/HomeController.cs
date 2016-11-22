using System;
using System.Linq;
using System.Web.Mvc;
using BlogSystem.Data;
using BlogSystem.Models;

namespace BlogSystem.Controllers
{
    public class HomeController : Controller
    {
        public BlogSystemDbContext BlogSystemDbContext { get; set; }
        public HomeController()
        {
            BlogSystemDbContext = new BlogSystemDbContext();
        }
        public ActionResult Index()
        {
            var posts = BlogSystemDbContext.Posts.OrderByDescending(p => p.DateCreated).ToList();
            return View(posts);
        }

    }
}