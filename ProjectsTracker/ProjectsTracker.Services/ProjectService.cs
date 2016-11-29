using ProjectsTracker.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectsTracker.Models;
using ProjectsTracker.Data;

namespace ProjectsTracker.Services
{
    public class ProjectService : BaseService<Project> ,IProjectService
    {
        public ProjectService(IBlogSystemData data)
            :base(data)
        {
        }

        public override IQueryable<Post> GetAll()
        {
            return base.GetAll().OrderByDescending(p => p.CreatedOn);
        }

        public override void Add(Post entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
            base.SaveChanges();
        }
    }
}
