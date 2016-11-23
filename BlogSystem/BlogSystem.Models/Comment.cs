using System;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace BlogSystem.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}