namespace ProjectsTracker.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    //using ProjectsTracker.Data.Migrations;
    using Models;

    public class ProjectsTrackerDbContext : IdentityDbContext
    {
        public ProjectsTrackerDbContext()
            : base("ProjectsTrackerConnection")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProjectsTrackerDbContext, Configuration>());
        }

        public IDbSet<ApplicationUser> Users
        {
            get;
            set;
        }

        public IDbSet<Project> Projects
        {
            get;
            set;
        }

        public static ProjectsTrackerDbContext Create()
        {
            return new ProjectsTrackerDbContext();
        }
    }
}
