using ProjectsTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsTracker.Services.Contracts
{
    public interface IPTaskService : IService<PTask>
    {
        IQueryable<PTask> GetAll();

        void Add(PTask entity);

        void Update(PTask entity, string ownerId = null, string authorId = null);

        void SoftDelete(PTask entity);
        
    }
}
