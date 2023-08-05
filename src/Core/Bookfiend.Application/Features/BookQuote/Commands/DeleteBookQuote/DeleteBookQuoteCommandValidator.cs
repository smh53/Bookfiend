using FluentValidation;

namespace Bookfiend.Application.Features.BookQuote.Commands.DeleteBookQuote
{
    internal class DeleteBookQuoteCommandValidator : AbstractValidator<DeleteBookQuoteCommand>
    {
        public DeleteBookQuoteCommandValidator()
        {
            RuleFor(r => r.Id)
           .NotEmpty();
      
        }
    }
}