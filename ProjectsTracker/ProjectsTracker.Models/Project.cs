namespace ProjectsTracker.Models
{
    public class Project : BaseModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public string AuthorId { get; set; }
    }
}