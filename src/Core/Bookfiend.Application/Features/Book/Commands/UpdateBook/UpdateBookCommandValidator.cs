using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.Book.Commands.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(r => r.Name)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();
            RuleFor(r => r.PublishYear)
                .LessThanOrEqualTo(DateTime.UtcNow.Year);
          
        }
    }
}
