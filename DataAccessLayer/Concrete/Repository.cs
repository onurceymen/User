using DataAccessLayer.Abstract;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly UserDbContext _projectDbContext;
        public Repository(UserDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }
        public void Delete(T entity)
        {
            _projectDbContext.Set<T>().Remove(entity);
            _projectDbContext.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return _projectDbContext.Set<T>().FirstOrDefault(predicate);
        }

        public T GetByID(int id)
        {
            return _projectDbContext.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            _projectDbContext.Set<T>().Add(entity);
            _projectDbContext.SaveChanges();
        }

        public List<T> List()
        {
            return _projectDbContext.Set<T>().ToList();
        }

        public List<T> List(Expression<Func<T, bool>> predicate)
        {
            return _projectDbContext.Set<T>().Where(predicate).ToList();
        }

        public void Update(T entity)
        {
            _projectDbContext.Entry(entity).State = EntityState.Modified;
            _projectDbContext.SaveChanges();
        }
    }
}
