using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.Author.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(r => r.FirstName)
            
            .Length(2, 25).WithMessage(" First Name must be between 2 - 25 characters ")
            .Must(IsValidName).WithMessage(" {PropertyName} should be all letters ");

            RuleFor(r => r.LastName)
            
            .Length(2, 25).WithMessage(" Last Name must be between 2 - 25 characters ")
            .Must(IsValidName).WithMessage(" {PropertyName} should be all letters ");

           
        }
        private bool IsValidName(string name)
        {
            return name.All(Char.IsLetter);
        }
    }
}
