﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        T GetByID(int id);

        List<T> List(Expression<Func<T, bool>> where);
        T Find(Expression<Func<T, bool>> where);
    }
}
