using Domain.CoreDomain.Entities;
using Domain.CoreDomain.Helpers;

namespace Domain.Library.Entities
{
    public class Book : Entity<Book>
    {
        public string Name { get; set; }

        public string ISBN { get; set; }

        public string Category { get; set; }
        
        public override bool IsValid()
        {
            if (string.IsNullOrEmpty(Name)) ValidationResult.Errors.Add("Name is empty");

            if (string.IsNullOrEmpty(ISBN)) ValidationResult.Errors.Add("ISBN is empty");

            if (string.IsNullOrEmpty(Category)) ValidationResult.Errors.Add("Category is empty");

            return ValidationResult.IsValid;
        }
    }
}
