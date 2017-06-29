using Domain.CoreDomain.Entities;
using Domain.CoreDomain.Helpers;
using Domain.CoreDomain.Interfaces;
using System;

namespace Domain.CoreDomain.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : Entity<TEntity>
    {
        protected readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual ValidationResult Insert(TEntity obj)
        {
            if (!obj.IsValid()) return obj.ValidationResult;
                _repository.Insert(obj);

            return null;
        }

        public virtual void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public ValidationResult Update(TEntity obj)
        {
            if (!obj.IsValid()) return obj.ValidationResult;
                _repository.Update(obj);

            return null;
        }
    }
}
