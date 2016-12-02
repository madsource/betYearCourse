﻿using System;
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

        [DataType(DataType.Date)]
        [Display(Name = "Created on")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }

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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateFinished { get; set; }

        [Required]
        [Display(Name = "Is Active")]
        public bool isActive { get; set; }

        [Display(Name = "Estimated Budget")]
        [DataType(DataType.Currency)]
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