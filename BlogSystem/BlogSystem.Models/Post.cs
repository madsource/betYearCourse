using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace BlogSystem.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Content { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}

