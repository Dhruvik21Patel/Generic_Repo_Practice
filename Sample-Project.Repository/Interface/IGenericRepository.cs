using Sample_Project.entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Project.Repository.Interface
{
    public interface IGenericRepository<T> where T:BaseEntity
    {
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<TResult> FindBy<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        IQueryable<T> QueryableData(Expression<Func<T, bool>> condition);
        bool Any(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
