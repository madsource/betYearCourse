using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectsTracker.ViewModels
{
    public class TimeReportItemViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        [Required]
        [Range(0.1, 100)]
        public float HoursSpend { get; set; }
    }
}