using FluentValidation.Results;

namespace Bookfiend.Application.Exceptions
{

        public class BadRequestException : Exception
        {
            public BadRequestException(string message) : base(message)
            {
                
            }

        public BadRequestException(string message, FluentValidation.Results.ValidationResult validationResult) : base(message)
        {
            ValidationErrors = validationResult.ToDictionary();

        }

        public IDictionary<string, string[]> ValidationErrors { get; set; }
    }
    
}
