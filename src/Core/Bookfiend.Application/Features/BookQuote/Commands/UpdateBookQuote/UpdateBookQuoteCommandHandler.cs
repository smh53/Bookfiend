using Bookfiend.Application.Contracts.Persistence;
using Bookfiend.Application.Exceptions;
using Bookfiend.Application.Features.Author.Commands.UpdateAuthor;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.BookQuote.Commands.UpdateBookQuote
{
    public class UpdateBookQuoteCommandHandler : IRequestHandler<UpdateBookQuoteCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IBookQuoteRepository _bookQuoteRepository;

        public UpdateBookQuoteCommandHandler(IMapper mapper, IBookQuoteRepository bookQuoteRepository)
        {
            _mapper = mapper;
            _bookQuoteRepository = bookQuoteRepository;
        }

        public async Task<Unit> Handle(UpdateBookQuoteCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBookQuoteCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid Book Quote", validationResult);

            var bookQuoteUpdate = _mapper.Map<Domain.BookQuote>(request);
            await _bookQuoteRepository.UpdateAsync(bookQuoteUpdate);

            return Unit.Value;
        }
    }
}
