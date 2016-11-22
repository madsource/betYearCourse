using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BlogSystem.Data;
using BlogSystem.Models;
using BlogSystem.ViewModels;

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
            ICollection<PostViewModel> posts = BlogSystemDbContext.Posts.Select(p => new PostViewModel()
            {
                Content = p.Content,
                Name = p.Name,
                DateCreated = p.DateCreated,
                Username = p.User.UserName,
                Id = p.Id
            }).OrderByDescending(p => p.DateCreated).ToList();
            return View(posts);
        }

    }
}