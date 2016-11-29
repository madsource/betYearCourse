using System;

namespace ProjectsTracker.Models
{
    public class Metric : BaseModel
    {
        public DateTime Date { get; set; }
        public decimal Revenue { get; set; }
        public decimal CashInput { get; set; }
        public float HoursSpend { get; set; }
        public ApplicationUser ReportedBy { get; set; }
    }
}