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

        [Display(Name = "Created on")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Updated on")]
        public DateTime? UpdatedOn { get; set; }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted { get; set; }

        [Required]
        public ApplicationUserViewModel Author { get; set; }

        public string OwnerId { get; set; }
        public string AuthorId { get; set; }
        public ApplicationUserViewModel Owner { get; set; }        

        public string Description { get; set; }

        [Required]
        [StringLength(500)]
        public string Title { get; set; }

        [Display(Name = "Estimated hours")]
        public float EstimatedHours { get; set; }

        [Display(Name = "Hours spend")]
        [Range(1, 100)]
        public float HoursSpend { get; set; }
        public ICollection<TimeReportItemViewModel> TimeReportList { get; set; }

        [Display(Name = "Progress")]
        public float ProgressPercent { get; set; }

        public PTaskViewModel()
        {
            TimeReportList = new HashSet<TimeReportItemViewModel>();
            HoursSpend = 1;
        }

        public float TotalTimeSpend { get; set; }
    }
}