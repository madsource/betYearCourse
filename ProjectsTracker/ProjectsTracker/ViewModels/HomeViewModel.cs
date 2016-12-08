﻿using PagedList;
using ProjectsTracker.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectsTracker.ViewModels
{
    public class HomeViewModel
    {
        //public int NumberOfTasksInProgress { get; private set; }
        //public int NumberOfTasksFinished { get; private set; }
        //public int NumberOfTasksNotStarted { get; private set; }
        //public int NumberOfAllTasks { get; private set; }
        //public double TotalAmountSpend { get; private set; }
        //public double TotalBudget { get; private set; }

        //public int ProjectsActive { get; private set; }
        //public int ProjectsInProgress { get; private set; }
        //public int ProjectsFinished { get; private set; }

        public IDictionary<string, object> Statistics { get; set; }
        
        public IPagedList<ProjectViewModel> Projects { get; set; }

        public HomeViewModel( IPagedList<ProjectViewModel> projects, IDictionary<string, object> statistics)
        {
            this.Projects = projects;
            this.Statistics = statistics;
            //if(this.Projects != null && this.Projects.Any())
            //{
            //    this.NumberOfTasksFinished = this.Projects.Sum(p => p.GetNumberOfTasksFinished());
            //    this.NumberOfTasksInProgress = this.Projects.Sum(p => p.GetNumberOfTasksInProgress());
            //    this.NumberOfTasksNotStarted = this.Projects.Sum(p => p.GetNumberOfTasksNotStarted());
            //    this.TotalAmountSpend = this.Projects.Sum(p => p.GetTotalTimeSpend() * (double)PtConstants.RatePerHour);
            //    this.TotalBudget = this.Projects.Sum(p => (double)p.EstimatedBudget);
            //    this.ProjectsActive = this.Projects.Where(p => p.isActive == true).Count();
            //    this.ProjectsInProgress = this.Projects
            //        .Where(p => p.isActive == true && p.Tasks.Where(t => t.ProgressPercent < 100).Count() > 0)
            //        .Count();
            //    this.ProjectsFinished = this.Projects
            //        .Where(p => p.isActive == true && p.Tasks
            //              .Where(t => t.ProgressPercent == 100).Count() == p.Tasks.Count() && p.Tasks.Count() > 0)
            //        .Count();

            //    this.NumberOfAllTasks = this.Projects.Sum(p => p.Tasks.Count());
            //}            
        }
    }
}