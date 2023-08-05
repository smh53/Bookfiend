using Bookfiend.Application.Contracts.Persistence;
using Bookfiend.Application.Features.Author.Queries.GetAllAuthors;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.BookQuote.Queries.GetAllBookQuotes
{
    public class GetAllBookQuotesQueryHandler : IRequestHandler<GetAllBookQuotesQuery, List<BookQuoteDto>>
    {
        private readonly IBookQuoteRepository _bookQuoteRepository;
        private readonly IMapper _mapper;

        public GetAllBookQuotesQueryHandler(IBookQuoteRepository bookQuoteRepository, IMapper mapper)
        {
            _bookQuoteRepository = bookQuoteRepository;
            _mapper = mapper;
        }

        public async Task<List<BookQuoteDto>> Handle(GetAllBookQuotesQuery request, CancellationToken cancellationToken)
        {
            var bookQuotes = await _bookQuoteRepository.GetAllBookQuotesWithBooksAndTheirAuthors();

            var data = _mapper.Map<List<BookQuoteDto>>(bookQuotes);

            return data;
        }
    }
}
