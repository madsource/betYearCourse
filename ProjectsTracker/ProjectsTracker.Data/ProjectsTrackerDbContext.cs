namespace ProjectsTracker.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    //using ProjectsTracker.Data.Migrations;
    using Models;
    using Models.Extensions;
    using System.Data.Entity.Validation;

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

        public IDbSet<PTask> PTasks
        {
            get;
            set;
        }

        public IDbSet<Comment> Comments
        {
            get;
            set;
        }

        public IDbSet<Metric> Metrics
        {
            get;
            set;
        }

        public IDbSet<TimeReportItem> TimeReportItems
        {
            get;
            set;
        }


        public static ProjectsTrackerDbContext Create()
        {
            return new ProjectsTrackerDbContext();
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                throw newException;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PTask>()
                   .HasMany(t => t.TimeReportList)
                   .WithOptional()
                   .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}
