﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TaskManager.DAL.Interfaces
{
    public interface IRepositoryBase<T>
    {
        void Create(T value);
        void Update(T value);
        void Delete(T value);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
    }
}
