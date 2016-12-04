using System;

namespace ProjectsTracker.Models
{
    public class TimeReportItem : BaseModel
    {
        public DateTime ReportedOn { get; set; }
        public float HoursSpend { get; set; }
    }
}