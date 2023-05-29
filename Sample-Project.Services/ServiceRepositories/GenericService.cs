using Sample_Project.entities.Entities;
using Sample_Project.entities.ViewModels;
using Sample_Project.Repository.Interface;
using Sample_Project.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Project.Services.ServiceRepositories
{
    public abstract class GenericService<T> : IGenericService<T> where T : BaseEntity
    {
        private readonly IGenericRepository<T> _genericRepository;
        public GenericService(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            //AddUpdateSkillViewModel addUpdateSkill = new AddUpdateSkillViewModel();
            _genericRepository.Add(entity);

        }


        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _genericRepository.Edit(entity);
        }
        public virtual bool Any(Expression<Func<T, bool>> predicate)
        {
            return _genericRepository.Any(predicate);
        }
        public virtual T GetT(Expression<Func<T, bool>> predicate)
        {
            return _genericRepository.FindBy(predicate).FirstOrDefault();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _genericRepository.Delete(entity);
        }
    }
}
