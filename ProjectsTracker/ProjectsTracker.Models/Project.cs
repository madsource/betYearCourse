using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectsTracker.Models
{
    public class Project : BaseModel
    {
        [Required]
        public string Title { get; set; }

        public string Content { get; set; }
        [Required]
        public virtual ApplicationUser Owner { get; set; }

        public DateTime ExpectedEndDate { get; set; }

        public DateTime? DateFinished { get; set; }
        [Required]
        public bool isActive { get; set; }
        [Required]
        public decimal EstimatedBudget { get; set; }
        [Required]
        public string ClientName { get; set; }

        public virtual ICollection<PTask> Tasks { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Metric> Metrics { get; set; }

        public Project()
        {
            this.Tasks = new HashSet<PTask>();
            this.Comments = new HashSet<Comment>();
            this.Metrics = new HashSet<Metric>();
        }

    }
}