namespace ProjectsTracker.Services
{
    using ProjectsTracker.Services.Contracts;
    using System;
    using System.Linq;
    using ProjectsTracker.Models;
    using ProjectsTracker.Data;

    public class ProjectService : BaseService<Project>, IProjectService
    {
        public ProjectService(IProjectsTrackerData data)
            : base(data)
        {
        }

        public override IQueryable<Project> GetAll()
        {
            return base.GetAll().OrderByDescending(p => p.CreatedOn);
        }

        public override void Add(Project entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
            base.SaveChanges();
        }

        public override void Update(Project entity)
        {
            entity.UpdatedOn = DateTime.Now;
            base.Update(entity);
            base.SaveChanges();
        }

        public void SoftDelete(object Id)
        {
            var entity = this.Find(Id);
            entity.UpdatedOn = DateTime.Now;
            entity.IsDeleted = true;
            base.Update(entity);
            base.SaveChanges();
        }
    }
}
