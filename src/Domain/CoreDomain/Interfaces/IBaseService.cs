using Domain.CoreDomain.Entities;
using Domain.CoreDomain.Helpers;
using System;

namespace Domain.CoreDomain.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : Entity<TEntity>
    {
        ValidationResult Insert(TEntity obj);

        void Delete(Guid id);

        ValidationResult Update(TEntity obj);
    }
}
