using EFWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFWeb.Model;

namespace EFWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new EfDBContext();
            db.Posts.Add(new Post()
            {
                Name = "Gosho",
                Author = "GoshoAuthor"
            });

            var tag = new Tag()
            {
                Name = "Entity Framework"
            };

            db.Tags.Add(tag);

            
            var posts = db.Posts.ToList();
            posts[0].Tags.Add(tag);

            db.SaveChanges();
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