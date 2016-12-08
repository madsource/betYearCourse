using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProjectsTracker.Models;
using System.Web.Mvc;
using ProjectsTracker.Common;

namespace ProjectsTracker.ViewModels
{
    public class ProjectViewModel : IValidatableObject
    {
        
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created on")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Updated on")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? UpdatedOn { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(10000)]
        public string Content { get; set; }

        public ApplicationUserViewModel Owner { get; set; }

        //public string OwnerId { get; set; }
        [Required]
        [Display(Name = "Expected End Date")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExpectedEndDate { get; set; }

        [Display(Name = "Date Finished")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true )]
        public DateTime? DateFinished { get; set; }

        [Required]
        [Display(Name = "Is Active")]
        public bool isActive { get; set; }

        [Display(Name = "Estimated Budget")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:D}", ApplyFormatInEditMode = true)]
        public decimal EstimatedBudget { get; set; }

        [Required]
        [Display(Name = "Client Name")]
        [StringLength(100)]
        public string ClientName { get; set; }

        public ICollection<PTaskViewModel> Tasks { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Metric> Metrics { get; set; }
        public ICollection<ApplicationUserViewModel> WorkingUsers { get; set; }

        public SelectList Users { get; set; }

        [DisplayFormat(DataFormatString = "{0:00,00}")]
        public float Progress { get; set; }

        public float TotalTimeSpend { get; set; }

        public string Status { get; set; }

        public ProjectViewModel()
        {
            this.Tasks = new HashSet<PTaskViewModel>();
            this.Comments = new HashSet<Comment>();
            this.Metrics = new HashSet<Metric>();
            this.WorkingUsers = new List<ApplicationUserViewModel>();
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