using System;
using System.Linq;
using System.Web.Mvc;
using BlogSystem.Models;
using BlogSystem.ViewModels;
using Microsoft.AspNet.Identity;

namespace BlogSystem.Controllers
{
    public class CommentsController : RootController
    {

        [HttpGet]
        [Authorize]
        public ActionResult AddComment(int id)
        {
            //this.PostModel = this.BlogSystemDbContext.Posts.FirstOrDefault(p => p.Id == id);

            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddComment(CommentViewModel commentViewModel, int id)
        {
            Post PostModel = this.BlogSystemDbContext.Posts.FirstOrDefault(p => p.Id == id);

            Comment newComment = new Comment()
            {
                Author = this.UserManager.FindById(User.Identity.GetUserId()).UserName,
                CreatedAt = DateTime.Now,
                Text = commentViewModel.Text
            };

            PostModel.Comments.Add(newComment);
            this.BlogSystemDbContext.SaveChanges();

            return RedirectToAction("Index", "Post", new {id});
        }

        public ActionResult Update(int commentId)
        {
            throw new NotImplementedException();
        }
    }
}