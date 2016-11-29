namespace ProjectsTracker.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using ProjectsTracker.Data.Repositories;
    using ProjectsTracker.Models;

    public class ProjectsTrackerData : IProjectsTrackerData
    {
        private DbContext context;
        private Dictionary<Type, object> repositories;

        public ProjectsTrackerData()
            : this(new ProjectsTrackerDbContext())
        {
        }

        public ProjectsTrackerData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IRepository<Project> Projects
        {
            get
            {
                return this.GetRepository<Project>();
            }
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(Repository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>) this.repositories[typeOfRepository];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
