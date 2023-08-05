using Bookfiend.Application.Contracts.Persistence;
using Bookfiend.Application.Exceptions;
using Bookfiend.Application.Features.Author.Commands.CreateAuthor;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.BookQuote.Commands.CreateBookQuote
{
    public class CreateBookQuoteCommandHandler : IRequestHandler<CreateBookQuoteCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IBookQuoteRepository _bookQuoteRepository;

        public CreateBookQuoteCommandHandler(IBookQuoteRepository bookQuoteRepository, IMapper mapper)
        {
            _bookQuoteRepository = bookQuoteRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateBookQuoteCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBookQuoteCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid Book Quote", validationResult);

            var newBookQuote = _mapper.Map<Domain.BookQuote>(request);
            await _bookQuoteRepository.CreateAsync(newBookQuote);
            return Unit.Value;
        }
    }
}
