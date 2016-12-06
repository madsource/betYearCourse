using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectsTracker.Models
{
    public class PTask : BaseModel
    {
        [Required]
        public virtual ApplicationUser Author { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public string AuthorId { get; set; }
        public string OwnerId { get; set; }

        public string Description { get; set; }

        [Required]
        public string Title { get; set; }

        public float EstimatedHours { get; set; }

        public virtual ICollection<TimeReportItem> TimeReportList { get; set; }

        public float ProgressPercent { get; set; }

        public PTask()
        {
            TimeReportList = new HashSet<TimeReportItem>();
        }
    }
}