using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.Author.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(r => r.Firstname).NotEmpty().NotNull().MaximumLength(30);
            RuleFor(r => r.Lastname).NotEmpty().NotNull().MaximumLength(50);
        }
    }
}
