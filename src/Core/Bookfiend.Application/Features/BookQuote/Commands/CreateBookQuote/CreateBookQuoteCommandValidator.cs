using FluentValidation;

namespace Bookfiend.Application.Features.BookQuote.Commands.CreateBookQuote
{
    internal class CreateBookQuoteCommandValidator : AbstractValidator<CreateBookQuoteCommand>
    {
        public CreateBookQuoteCommandValidator()
        {
            RuleFor(r => r.Quote).NotEmpty();
            RuleFor(r => r.BookId).NotNull();
            RuleFor(r => r.PageNumber).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}