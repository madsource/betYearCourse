using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectsTracker.ViewModels
{
    public class TimeReportItemViewModel
    {
        public DateTime ReportedOn { get; set; }
        [Required]
        [Range(0.1, 100)]
        public float HoursSpend { get; set; }
    }
}