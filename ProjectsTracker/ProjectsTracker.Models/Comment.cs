using System.ComponentModel.DataAnnotations;

namespace ProjectsTracker.Models
{
    public class Comment: BaseModel
    {
        [Required]
        public ApplicationUser User { get; set; }
        [Required]
        public string Text { get; set; }
    }
}