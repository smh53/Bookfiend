using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.Book.Commands.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(r => r.Id)
            .NotEmpty()
            .NotNull();
        }
    }
}
