using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.Book.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
            RuleFor(r => r.PublishYear)
                .LessThanOrEqualTo(DateTime.UtcNow.Year);
            RuleFor(r => r.Volume)
                .GreaterThanOrEqualTo(1);
            RuleFor(r=> r.Printary)
                .NotEmpty()
                .NotNull();
            
             
        }
    }
}
