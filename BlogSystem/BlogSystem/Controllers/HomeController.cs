using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BlogSystem.Data;
using BlogSystem.Models;
using BlogSystem.ViewModels;

namespace BlogSystem.Controllers
{
    public class HomeController : RootController
    {
        public ActionResult Index()
        {
            ICollection<PostViewModel> posts = BlogSystemDbContext.Posts.Select(p => new PostViewModel()
            {
                Content = p.Content,
                Name = p.Name,
                DateCreated = p.DateCreated,
                Username = p.User.UserName,
                Id = p.Id,
                Comments = p.Comments.Select(c => new CommentViewModel()
                {
                    Text = c.Text,
                    Author = c.Author,
                    Id = c.Id,
                    CreatedAt = c.CreatedAt
                }).ToList()
            }).OrderByDescending(p => p.DateCreated).Take(12).ToList();
            return View(posts);
        }
    }
}