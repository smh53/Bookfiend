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
    public class CreateBookQuoteCommandHandler : IRequestHandler<CreateBookQuoteCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IBookQuoteRepository _bookQuoteRepository;

        public CreateBookQuoteCommandHandler(IBookQuoteRepository bookQuoteRepository, IMapper mapper)
        {
            _bookQuoteRepository = bookQuoteRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateBookQuoteCommand request, CancellationToken cancellationToken)
        {          
            var newBookQuote = _mapper.Map<Domain.BookQuote>(request);
           var createdBookQuoteId = await _bookQuoteRepository.CreateAsync(newBookQuote);
            return createdBookQuoteId;
        }
    }
}
