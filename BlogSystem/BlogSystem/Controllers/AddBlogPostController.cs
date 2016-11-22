using System;
using System.Linq;
using System.Web.Mvc;
using BlogSystem.Data;
using BlogSystem.Models;
using BlogSystem.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Post = BlogSystem.ViewModels.Post;

namespace BlogSystem.Controllers
{
    public class AddBlogPostController : Controller
    {
        private BlogSystemDbContext dbContext;
        private UserManager<ApplicationUser> UserManager;
        public AddBlogPostController()
        {
            this.dbContext = new BlogSystemDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.dbContext));
        }

        public ActionResult Index(int id)
        {
            Post postViewModel = new ViewModels.Post();
            if (id != null)
            {
                var postModel = dbContext.Posts.FirstOrDefault(p => p.Id == id);
                postViewModel.Name = postModel.Name;
                postViewModel.Content = postModel.Content;
                postViewModel.DateCreated = postModel.DateCreated;
                postViewModel.Id = postModel.Id;
                postViewModel.User = postModel.User;
            }
  
            return View(postViewModel);
        }

        [HttpPost]
        public ActionResult NewBlogPost(ViewModels.Post post)
        {
            var newPost = new Models.Post()
            {
                Name = post.Name,
                Content = post.Content,
                DateCreated = DateTime.Now,
                User = UserManager.FindById(User.Identity.GetUserId())
            };
            this.dbContext.Posts.Add(newPost);
            dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}