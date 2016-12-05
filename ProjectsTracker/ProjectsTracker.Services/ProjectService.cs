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
            return base.GetAll().Where(p => p.IsDeleted != true).OrderByDescending(p => p.CreatedOn);
        }

        public override Project Find(object Id)
        {
            Project project = base.Find(Id);
            if(project != null)
            {
                project.Owner = base.Data.Users.Find(project.Owner.Id);
            }            
            return project;
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

        public void SoftDelete(Project entity)
        {
            entity.UpdatedOn = DateTime.Now;
            entity.IsDeleted = true;
            base.Update(entity);
            base.SaveChanges();
        }

        public Project AddTask(Project project, PTask task)
        {
            task.CreatedOn = DateTime.Now;
            project.Tasks.Add(task);
            base.Update(project);
            base.SaveChanges();
            return project;
        }
    }
}
