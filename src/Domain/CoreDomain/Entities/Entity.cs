using Domain.CoreDomain.Helpers;
using System;

namespace Domain.CoreDomain.Entities
{
    public abstract class Entity<T> where T : class
    {
        public Guid Id { get; set; }
        
        public Entity()
        {
            Id = Guid.NewGuid();
            ValidationResult = new ValidationResult();
        }
        
        public ValidationResult ValidationResult { get; set; }

        public virtual bool IsValid()
        {
            return ValidationResult.IsValid;
        }
    }
}
