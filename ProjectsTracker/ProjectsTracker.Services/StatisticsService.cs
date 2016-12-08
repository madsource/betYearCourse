using ProjectsTracker.Services.Contracts;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectsTracker.Models;
using ProjectsTracker.Data;
using System.Linq;
using ProjectsTracker.Common;

namespace ProjectsTracker.Services
{
    public class StatisticsService : BaseService<Project>, IStatisticsService
    {
        public StatisticsService(IProjectsTrackerData data)
            : base(data)
        {
            
        }

        public IDictionary<string, double> GetStatisticsForProjects()
        {
            Dictionary<string, double> projectsStatsDictionary = new Dictionary<string, double>();

            var projects = base.GetAll().ToList();

            if (projects != null && projects.Any())
            {               
                double NumberOfTasksFinished = projects.Sum(p => GetNumberOfTasksFinished(p));
                projectsStatsDictionary.Add("NumberOfTasksFinished", NumberOfTasksFinished);

                double NumberOfTasksInProgress = projects.Sum(p => GetNumberOfTasksInProgress(p));
                projectsStatsDictionary.Add("NumberOfTasksInProgress", NumberOfTasksInProgress);

                double NumberOfTasksNotStarted = projects.Sum(p => GetNumberOfTasksNotStarted(p));
                projectsStatsDictionary.Add("NumberOfTasksNotStarted", NumberOfTasksNotStarted);

                double TotalAmountSpend = projects.Sum(p => GetProjectTotalTimeSpend(p) * (double)PtConstants.RatePerHour);
                projectsStatsDictionary.Add("TotalAmountSpend", TotalAmountSpend);

                double TotalBudget = projects.Sum(p => (double)p.EstimatedBudget);
                projectsStatsDictionary.Add("TotalBudget", TotalBudget);

                double projectsActive = projects.Where(p => p.isActive == true).Count();
                projectsStatsDictionary.Add("ProjectsActive", projectsActive);

                double projectsInProgress = projects
                    .Where(p => p.isActive == true && p.Tasks.Where(t => t.ProgressPercent < 100).Count() > 0)
                    .Count();
                projectsStatsDictionary.Add("ProjectsInProgress", projectsInProgress);

                double projectsFinished = projects
                    .Where(p => p.isActive == true && p.Tasks
                          .Where(t => t.ProgressPercent == 100).Count() == p.Tasks.Count() && p.Tasks.Count() > 0)
                    .Count();
                projectsStatsDictionary.Add("ProjectsFinished", projectsFinished);

                double NumberOfAllTasks = projects.Sum(p => p.Tasks.Count());
                projectsStatsDictionary.Add("NumberOfAllTasks", NumberOfAllTasks);

                double NumberOfAllProjects = projects.Count;
                projectsStatsDictionary.Add("NumberOfAllProjects", NumberOfAllProjects);
            }

            return projectsStatsDictionary;
        }

        public ICollection<ApplicationUser> GetProjectUsers(Project project)
        {
            List<ApplicationUser> users = new List<ApplicationUser>();

            if (project.Tasks.Any())
            {
                foreach (var task in project.Tasks)
                {
                    if (users.FirstOrDefault(u => u.Id == task.Owner.Id) == null)
                    {
                        // user not added, so add it
                        users.Add(task.Owner);
                    }
                }
            }

            return users;
        }

        public float GetProjectTotalTimeSpend(Project project)
        {
            float time = 0;

            if (project.Tasks.Any())
            {
                foreach (var task in project.Tasks)
                {
                    time += GetTaskTimeSpend(task);
                }
            }

            return time;
        }

        public int GetNumberOfTasksInProgress(Project project)
        {
            int number = project.Tasks.Where(t => t.ProgressPercent > 0).Count();
            return number;
        }

        public int GetNumberOfTasksNotStarted(Project project)
        {
            int number = project.Tasks.Where(t => t.ProgressPercent == 0).Count();
            return number;
        }

        public int GetNumberOfTasksFinished(Project project)
        {
            int number = project.Tasks.Where(t => t.ProgressPercent == 100).Count();
            return number;
        }

        public float GetTaskTimeSpend(PTask task)
        {
            float time = 0;

            if (task.TimeReportList.Any())
            {
                foreach (var report in task.TimeReportList)
                {
                    time += report.HoursSpend;
                }
            }

            return time;
        }

        public string GetProjectStatus(Project project)
        {
            double actualCost = 0;

            foreach (var task in project.Tasks)
            {
                actualCost += ((task.ProgressPercent / 100) * task.EstimatedHours) * PtConstants.RatePerHour;
            }

            if (actualCost > (double)project.EstimatedBudget + (double)project.EstimatedBudget * PtConstants.BudgetToleranceInPercents)
            {
                return "Red";
            }
            else if (((double)project.EstimatedBudget + (double)project.EstimatedBudget * PtConstants.BudgetToleranceInPercents) > actualCost
                && actualCost > (double)project.EstimatedBudget)
            {
                return "Amber";
            }
            else
            {
                return "Green";
            }
        }
    }
}
