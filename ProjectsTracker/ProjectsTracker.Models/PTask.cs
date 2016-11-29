using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectsTracker.Models
{
    public class PTask : BaseModel
    {
        [Required]
        public ApplicationUser Author { get; set; }

        public ApplicationUser Owner { get; set; }

        public string Description { get; set; }

        [Required]
        public string Title { get; set; }

        public float EstimatedHours { get; set; }

        public IDictionary<DateTime, float> HoursWorkedList { get; set; }

        public float ProgressPercent { get; set; }

        public PTask()
        {
            HoursWorkedList = new Dictionary<DateTime, float>();
        }
    }
}