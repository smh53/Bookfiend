using FluentValidation;

namespace Bookfiend.Application.Features.BookQuote.Commands.UpdateBookQuote
{
    internal class UpdateBookQuoteCommandValidator : AbstractValidator<UpdateBookQuoteCommand>
    {
        public UpdateBookQuoteCommandValidator()
        {
            RuleFor(r => r.Quote).NotEmpty();
            RuleFor(r => r.BookId).NotNull();
            RuleFor(r => r.PageNumber).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}