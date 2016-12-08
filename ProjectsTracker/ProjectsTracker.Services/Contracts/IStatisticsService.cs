using ProjectsTracker.Models;
using System.Collections.Generic;

namespace ProjectsTracker.Services.Contracts
{
    public interface IStatisticsService : IService<Project>
    {
        IDictionary<string, double> GetStatisticsForProjects();
        ICollection<ApplicationUser> GetProjectUsers(Project project);
        float GetProjectTotalTimeSpend(Project project);
        float GetTaskTimeSpend(PTask task);
        string GetProjectStatus(Project project);
    }
}