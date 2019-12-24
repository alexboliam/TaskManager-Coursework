using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TaskManager.DAL.Interfaces
{
    public interface IRepositoryBase<T>
    {
        void Create(T value);
        void Update(T value);
        void Delete(T value);
        ICollection<T> FindAll();
        ICollection<T> FindByCondition(Expression<Func<T, bool>> expression);
    }
}
