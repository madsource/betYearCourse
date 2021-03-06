﻿using System;
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
                Comments = existingPost.Comments.Select( c => new CommentViewModel()
                {
                   Text = c.Text,
                   Author = c.Author,
                   Id = c.Id,
                   CreatedAt = c.CreatedAt
                }).ToList()
            };

            return postViewModel;
        }

        [HttpGet]
        public ActionResult AddComment(int id)
        {
            return RedirectToAction("Index", new {id});
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddComment(CommentViewModel commentViewModel, int id)
        {
            Post postModel = this.BlogSystemDbContext.Posts.FirstOrDefault(p => p.Id == id);

            Comment newComment = new Comment()
            {
                Author = this.UserManager.FindById(User.Identity.GetUserId()).UserName,
                CreatedAt = DateTime.Now,
                Text = commentViewModel.Text
            };

            postModel.Comments.Add(newComment);
            this.BlogSystemDbContext.SaveChanges();

            var updatedPostViewModel = new PostViewModel()
            {
                Name = postModel.Name,
                Content = postModel.Content,
                Id = postModel.Id,
                DateCreated = postModel.DateCreated,
                Username = postModel.User.UserName,
                Comments = postModel.Comments.Select(c => new CommentViewModel()
                {
                    Text = c.Text,
                    Author = c.Author,
                    Id = c.Id,
                    CreatedAt = c.CreatedAt
                }).ToList()
            };
            
            return PartialView("_comments", updatedPostViewModel);
        }

        [HttpGet]
        [Authorize]
        public ActionResult EditComment(int commentid)
        {
            Comment existingComment = this.BlogSystemDbContext.Comments.FirstOrDefault(c => c.Id == commentid);

            if (existingComment == null)
            {
                return HttpNotFound();
            }

            CommentViewModel commentViewModel = new CommentViewModel()
            {
                Text = existingComment.Text,
                Author = existingComment.Author,
                CreatedAt = existingComment.CreatedAt,
                Id = existingComment.Id
            };

            return PartialView("_editComment", commentViewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditComment(CommentViewModel commentViewModel, int Id )
        {
            Comment existingComment = this.BlogSystemDbContext.Comments.FirstOrDefault(c => c.Id == Id);

            if (existingComment == null)
            {
                return HttpNotFound();
            }

            existingComment.CreatedAt = DateTime.Now;
            existingComment.Text = commentViewModel.Text;

            this.BlogSystemDbContext.SaveChanges();

            CommentViewModel updatedCommentViewModel = new CommentViewModel()
            {
                Text = existingComment.Text,
                Author = existingComment.Author,
                CreatedAt = existingComment.CreatedAt,
                Id = existingComment.Id
            };

           
            // get post of this comment
            Post existingPost = this.BlogSystemDbContext.Posts.Where(p => p.Comments.Any(c => c.Id == existingComment.Id)).ToList().First();

            var updatedPostViewModel = new PostViewModel()
            {
                Name = existingPost.Name,
                Content = existingPost.Content,
                Id = existingPost.Id,
                Comments = existingPost.Comments.Select(c => new CommentViewModel()
                {
                    Text = c.Text,
                    Author = c.Author,
                    Id = c.Id,
                    CreatedAt = c.CreatedAt
                }).ToList(),
                DateCreated = existingPost.DateCreated,
                Username = existingPost.User.UserName
            };

            return PartialView("_comment", updatedCommentViewModel);
        }
    }
}