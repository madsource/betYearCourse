using ProjectsTracker.Data.Repositories;

namespace ProjectsTracker.Data
{
    using ProjectsTracker.Data.Repositories;
    using ProjectsTracker.Models;

    public interface IProjectsTrackerData
    {
        IRepository<ApplicationUser> Users
        {
            get;
        }

        IRepository<Project> Projects
        {
            get;
        }

        IRepository<T> GetRepository<T>() where T:class;
    }
}
