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
    public class PostController : RootController
    {

        [HttpGet]
        [Authorize]
        public ActionResult Update(int? id)
        {          
            if (id == null)
            {
                PostViewModel postViewModel = new PostViewModel();
                return View(postViewModel);
            }
            else
            {
                var postViewModel = this.GetPost(id);
                return View(postViewModel);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Update(PostViewModel postViewModel)
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
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var postViewModel = this.GetPost(id);
                return View(postViewModel);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {

            return RedirectToAction("Index");

        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var existingPost = this.BlogSystemDbContext.Posts.FirstOrDefault(p => p.Id == id);

            var postName = existingPost.Name;
            var postAuthor = existingPost.User.UserName;

            if (existingPost == null)
            {
                return HttpNotFound();
            }

            // remove all comments first
            existingPost.Comments.ToList().ForEach(c => existingPost.Comments.Remove(c));
            // delete the actual post
            this.BlogSystemDbContext.Posts.Remove(existingPost);
            this.BlogSystemDbContext.SaveChanges();

            return RedirectToAction("Update", new { deletedName = postName, deletedAuthor = postAuthor });
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