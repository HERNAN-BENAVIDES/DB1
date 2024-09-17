using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ProyectofinalDb1.data;

namespace ProyectofinalDb1.repository
{
    public class Repository<T> where T : class
    {
        private readonly DataContext _dataContext;
        internal DbSet<T> dbSet;

        public Repository(DataContext dataContext)
        {
            this._dataContext = dataContext;
            this.dbSet = _dataContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dataContext.Set<T>().ToList();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public bool Any(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            return query.Any(filter);
        }

        public bool Add(T entity)
        {
            this.dbSet.Add(entity);
            return Save();
        }

        public bool Delete(T entity)
        {
            this.dbSet.Remove(entity);
            return Save();
        }

        public bool DeleteRange(IEnumerable<T> entity)
        {
            this.dbSet.RemoveRange(entity);
            return Save();
        }

        public bool Update(T data)
        {
            this.dbSet.Update(data);
            return Save();
        }

        public bool Save()
        {
            return _dataContext.SaveChanges() > 0;
        }

     

        internal IEnumerable<object> GetAllFilter(Func<T, bool> predicate)
        {
            return _dataContext.Set<T>().Where(predicate);
        }
    }
}
