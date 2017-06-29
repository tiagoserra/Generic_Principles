using Domain.CoreDomain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.CoreDomain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : Entity<TEntity>
    {
        void Insert(TEntity obj);

        void Delete(Guid id);

        void Update(TEntity obj);

        TEntity GetById(Guid id);

        IEnumerable<TEntity> GetAll();
    }
}
