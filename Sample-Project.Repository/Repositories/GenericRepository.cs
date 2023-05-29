using Microsoft.EntityFrameworkCore;
using Sample_Project.entities.Data;
using Sample_Project.entities.Entities;
using Sample_Project.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Project.Repository.Repositories
{
    public abstract class GenericRepository<T>:IGenericRepository<T>
      where T : BaseEntity
    {
        protected SampleDBContext _context;
        protected readonly DbSet<T> _dbset;

        public GenericRepository(SampleDBContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }
        public virtual bool Any(Expression<Func<T, bool>> predicate)
        {

            return _dbset.Any(predicate);
        }
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = _dbset.Where(predicate).AsQueryable();
            return query;
        }
        public IQueryable<TResult> FindBy<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = _dbset;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            IQueryable<TResult> result = query.Select(selector);
            return result;
        }
        public IQueryable<T> QueryableData(Expression<Func<T, bool>> condition)
        {
            return _context.Set<T>().Where(condition).AsQueryable();
        }
        public virtual void Add(T entity)
        {
            _dbset.Add(entity);
        }


        public virtual void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            //_context.Entry(entity).State = EntityState.Modified;
            _context.Update(entity);
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }
    }
}
