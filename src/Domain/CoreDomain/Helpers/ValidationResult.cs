using System.Collections.Generic;
using System.Linq;

namespace Domain.CoreDomain.Helpers
{
    public class ValidationResult
    {
        public bool IsValid
        {
            get => !Errors.Any();
        }

        public List<string> Errors { get; set; }

        public ValidationResult()
        {
            Errors = new List<string>();
        }
    }
}
