using ProjectsTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectsTracker.ViewModels
{
    public class PTaskViewModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public int OwnerId { get; set; }

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