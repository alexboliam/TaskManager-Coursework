using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TaskManager.DAL.Interfaces;

namespace TaskManager.DAL.Repositories
{
    abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected internal TaskManagerContext context { get;}

        public RepositoryBase(TaskManagerContext context)
        {
            this.context = context;
        }
        public void Create(T value)
        {
            this.context.Set<T>().Add(value);
        }
        public void Update(T value)
        {
            this.context.Set<T>().Update(value);
        }

        public void Delete(T value)
        {
            this.context.Set<T>().Remove(value);
        }

        public IEnumerable<T> FindAll()
        {
            return this.context.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.context.Set<T>().Where(expression);
        }

        
    }
}
