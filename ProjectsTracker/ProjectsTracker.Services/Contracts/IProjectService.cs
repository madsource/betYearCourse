using ProjectsTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsTracker.Services.Contracts
{
    public interface IProjectService : IService<Project>
    {
        IQueryable<Project> GetAll();

        void Add(Project entity);

        void Update(Project entity);

        void SoftDelete(Project entity);

        Project AddTask(Project project, PTask task); 
        
    }
}
