using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWeb.Model
{
    public class Post
    {
        [Required]
        public string Name { get; set; }
        public string Author { get; set; }
        // po konvencia e primary key, moje i bez [key]
        [Key]
        public int Id { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
