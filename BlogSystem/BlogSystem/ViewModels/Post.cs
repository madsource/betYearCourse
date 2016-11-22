using System;
using System.ComponentModel.DataAnnotations;
using BlogSystem.Models;

namespace BlogSystem.ViewModels
{
    public class Post
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
        public virtual ApplicationUser User { get; set; }

        public Post()
        {
            this.Name = "";
            this.Content = "";
        }
    }
}