using Sample_Project.entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Project.Services.Interface
{
    public interface IGenericService<T> where T : class
    {
        T GetT(Expression<Func<T, bool>> predicate);
        void Create(T entity);
        void Delete(T entity);
       
        void Update(T entity);
        bool Any(Expression<Func<T, bool>> predicate);
    }
}
