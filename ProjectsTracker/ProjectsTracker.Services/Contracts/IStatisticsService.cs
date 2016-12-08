using ProjectsTracker.Models;
using System.Collections.Generic;

namespace ProjectsTracker.Services.Contracts
{
    public interface IStatisticsService : IService<Project>
    {
        IDictionary<string, object> GetStatisticsForProjects();
        ICollection<ApplicationUser> GetProjectUsers(Project project);
    }
}