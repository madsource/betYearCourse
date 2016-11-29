namespace ProjectsTracker.Services
{
    using ProjectsTracker.Data;
    using ProjectsTracker.Data.Repositories;
    using ProjectsTracker.Services.Contracts;
    using System.Linq;

    public class BaseService<T> : IService<T> where T : class
    {
        private IRepository<T> repository;

        public BaseService(IProjectsTrackerData data)
        {
            this.Data = data;
            this.repository = data.GetRepository<T>();
        }

        protected IProjectsTrackerData Data { get; private set; }

        public virtual IQueryable<T> GetAll()
        {
            return this.repository.All();
        }

        public virtual T Find(object id)
        {
            return this.repository.Find(id);
        }

        public virtual void Add(T entity)
        {
            this.repository.Add(entity);
            this.repository.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            this.repository.Update(entity);
            this.repository.SaveChanges();
        }

        public virtual void Delete(object id)
        {
            this.repository.Delete(id);
            this.repository.SaveChanges();
        }

        public void SaveChanges()
        {
            this.repository.SaveChanges();
        }
    }
}
