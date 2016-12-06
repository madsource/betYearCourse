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

        void Update(PTask entity);

        void SoftDelete(PTask entity);
        PTask AddReport(PTask task, TimeReportItem report);

    }
}
