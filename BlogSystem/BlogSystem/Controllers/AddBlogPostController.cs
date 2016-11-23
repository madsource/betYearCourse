using System;
using System.Linq;
using System.Web.Mvc;
using BlogSystem.Data;
using BlogSystem.Models;
using BlogSystem.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Net;

namespace BlogSystem.Controllers
{
    public class AddBlogPostController : RootController
    {

        [HttpGet]
        [Authorize]
        public ActionResult Index(int? id)
        {
            PostViewModel postViewModel = new PostViewModel();
            if (id != null)
            {
                var postModel = BlogSystemDbContext.Posts.FirstOrDefault(p => p.Id == id);
                postViewModel.Name = postModel.Name;
                postViewModel.Content = postModel.Content;
                postViewModel.DateCreated = postModel.DateCreated;
                postViewModel.Id = postModel.Id;
                postViewModel.Username = postModel.User.UserName;
            }

            return View(postViewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult UpdateBlogPost(PostViewModel postViewModel)
        {
            if (postViewModel.Id != 0)
            {
                var existingPost = this.BlogSystemDbContext.Posts.FirstOrDefault(p => p.Id == postViewModel.Id);
                existingPost.Name = postViewModel.Name;
                existingPost.Content = postViewModel.Content;
                existingPost.DateCreated = DateTime.Now;
                existingPost.User = UserManager.FindById(User.Identity.GetUserId());

            }
            else
            {
                var newPost = new Models.Post()
                {
                    Name = postViewModel.Name,
                    Content = postViewModel.Content,
                    DateCreated = DateTime.Now,
                    User = UserManager.FindById(User.Identity.GetUserId())
                };
                this.BlogSystemDbContext.Posts.Add(newPost);
            }

            BlogSystemDbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult PreviewBlogPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var post = this.GetPost(id);
                return View(post);
            }
        }

        [HttpGet]
        public ActionResult DeleteBlogPost(int? id)
        {

            return RedirectToAction("PreviewBlogPost");

        }

        [HttpPost, ActionName("DeleteBlogPost")]
        public ActionResult DeleteConfirmed(int id)
        {
            var existingPost = this.BlogSystemDbContext.Posts.FirstOrDefault(p => p.Id == id);

            var postName = existingPost.Name;
            var postAuthor = existingPost.User.UserName;

            if (existingPost == null)
            {
                return HttpNotFound();
            }

            this.BlogSystemDbContext.Posts.Remove(existingPost);
            this.BlogSystemDbContext.SaveChanges();

            return RedirectToAction("Index", new { deletedName = postName, deletedAuthor = postAuthor });
        }

        private PostViewModel GetPost(int? id)
        {
            var existingPost = this.BlogSystemDbContext.Posts.FirstOrDefault(p => p.Id == id);

            if (existingPost == null)
            {
                return null;
            }

            PostViewModel postViewModel = new PostViewModel()
            {
                Name = existingPost.Name,
                Content = existingPost.Content,
                DateCreated = existingPost.DateCreated,
                Username = existingPost.User.UserName,
                Id = existingPost.Id,
                Comments = existingPost.Comments
            };

            return postViewModel;
        }
    }
}