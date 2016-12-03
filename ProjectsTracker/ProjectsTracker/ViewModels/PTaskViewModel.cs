using ProjectsTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectsTracker.ViewModels
{
    public class PTaskViewModel
    {
        [Required]
        public ApplicationUserViewModel Author { get; set; }

        public ApplicationUserViewModel Owner { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(500)]
        public string Title { get; set; }

        public float EstimatedHours { get; set; }

        public IDictionary<DateTime, float> HoursWorkedList { get; set; }

        public float ProgressPercent { get; set; }

        public PTaskViewModel()
        {
            HoursWorkedList = new Dictionary<DateTime, float>();
        }
    }
}