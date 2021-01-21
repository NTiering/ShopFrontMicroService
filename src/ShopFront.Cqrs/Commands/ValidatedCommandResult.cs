using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ShopFront.Cqrs.Commands
{
    public abstract class ValidatedCommandResult : ICommandResult
    {
        private List<ValidationResult> _validationResults = new List<ValidationResult>();
        public void Add(ValidationResult validationResult) => _validationResults.Add(validationResult);
        public bool IsValid => !_validationResults.Any();
        public ValidationResult[] ValidationResults => _validationResults.ToArray();
    }
}