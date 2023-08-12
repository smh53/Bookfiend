using Bookfiend.Application.Contracts.Persistence;
using Bookfiend.Application.Exceptions;
using Bookfiend.Application.Features.Author.Commands.DeleteAuthor;
using Bookfiend.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.BookQuote.Commands.DeleteBookQuote
{
    public class DeleteBookQuoteCommandHandler : IRequestHandler<DeleteBookQuoteCommand, Unit>
    {
        private readonly IBookQuoteRepository _bookQuoteRepository;

        public DeleteBookQuoteCommandHandler(IBookQuoteRepository bookQuoteRepository)
        {
            _bookQuoteRepository = bookQuoteRepository;
        }

        public async Task<Unit> Handle(DeleteBookQuoteCommand request, CancellationToken cancellationToken)
        {
            var bookQuote = await _bookQuoteRepository.GetByIdAsync(request.Id);
            if (bookQuote is null)
                throw new NotFoundException(nameof(Domain.BookQuote), request.Id);
            await _bookQuoteRepository.DeleteAsync(bookQuote);
            return Unit.Value;
        }
    }
}
