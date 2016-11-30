using System;
using System.Collections.Generic;

namespace ProjectsTracker.Models
{
    public class Project : BaseModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public DateTime ExpectedEndDate { get; set; }

        public DateTime? DateFinished { get; set; }

        public bool isActive { get; set; }

        public decimal EstimatedBudget { get; set; }

        public string ClientName { get; set; }

        public virtual ICollection<PTask> Tasks { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Metric> Metrics { get; set; }

    }
}