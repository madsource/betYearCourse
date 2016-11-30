using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProjectsTracker.Models;

namespace ProjectsTracker.ViewModels
{
    public class ProjectViewModel : IValidatableObject
    {
        
        public int Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(10000)]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Owner Name")]
        [StringLength(100)]
        public ApplicationUserViewModel Owner { get; set; }
        
        //public string OwnerId { get; set; }

        [Display(Name = "Expected End Date")]
        public DateTime? ExpectedEndDate { get; set; }

        [Display(Name = "Date Finished")]
        public DateTime? DateFinished { get; set; }

        [Required]
        [Display(Name = "Is Active")]
        public bool isActive { get; set; }

        [Display(Name = "Estimated Budget")]
        public decimal EstimatedBudget { get; set; }

        [Required]
        [Display(Name = "Client Name")]
        [StringLength(100)]
        public string ClientName { get; set; }

        public ICollection<PTask> Tasks { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Metric> Metrics { get; set; }

        public ProjectViewModel()
        {
            this.Tasks = new List<PTask>();
            this.Comments = new List<Comment>();
            this.Metrics = new List<Metric>();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.ExpectedEndDate < this.CreatedOn)
            {
                yield return
                  new ValidationResult(errorMessage: $"{this.ExpectedEndDate} must be greater than {this.CreatedOn}",
                                       memberNames: new[] { "ExpectedEndDate" });
            }

            if (this.DateFinished < this.CreatedOn)
            {
                yield return
                  new ValidationResult(errorMessage: $"{this.DateFinished} must be greater than {this.CreatedOn}",
                                       memberNames: new[] { "DateFinished" });
            }
        }
    }
}