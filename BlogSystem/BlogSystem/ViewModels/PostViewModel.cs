using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BlogSystem.Models;

namespace BlogSystem.ViewModels
{
    public class PostViewModel
    {
 
        public int Id { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string Name { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        [Display(Name = "Added on")]
        public DateTime DateCreated { get; set; }
        public string Username { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public PostViewModel()
        {
            this.Name = "";
            this.Content = "";
            this.Comments = new HashSet<CommentViewModel>();
        }
    }
}