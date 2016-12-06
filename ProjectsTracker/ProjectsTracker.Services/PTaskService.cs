using ProjectsTracker.Data;
using ProjectsTracker.Models;
using ProjectsTracker.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsTracker.Services
{
    public class PTaskService : BaseService<PTask>, IPTaskService
    {

        public PTaskService(IProjectsTrackerData data)
            : base(data)
        {
        }

        public override IQueryable<PTask> GetAll()
        {
            return base.GetAll().Where(t => t.IsDeleted != true).OrderByDescending(p => p.CreatedOn);
        }

        public override PTask Find(object Id)
        {
            PTask pTask = base.Find(Id);
            pTask.Owner = base.Data.Users.Find(pTask.OwnerId);
            pTask.Author = base.Data.Users.Find(pTask.AuthorId);
            return pTask;
        }

        public override void Add(PTask entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
            base.SaveChanges();
        }

        public override void Update(PTask entity)
        {            
            base.Update(entity);
            base.SaveChanges();
        }

        public void SoftDelete(PTask entity)
        {
            entity.UpdatedOn = DateTime.Now;
            entity.IsDeleted = true;
            base.Update(entity);
            base.SaveChanges();
        }

        public PTask AddReport(PTask task, TimeReportItem report)
        {
            task.UpdatedOn = DateTime.Now;

            if (report != null)
            {
                report.CreatedOn = DateTime.Now;
                task.TimeReportList.Add(report);
            }

            base.Update(task);
            base.SaveChanges();
            return task;
        }
    }
}
