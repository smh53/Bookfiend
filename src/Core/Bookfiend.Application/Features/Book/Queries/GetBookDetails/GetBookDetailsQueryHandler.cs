using Bookfiend.Application.Contracts.Persistence;
using Bookfiend.Application.Features.Book.Queries.GetAllBooks;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.Book.Queries.GetBookDetails
{
    public class GetBookDetailsQueryHandler : IRequestHandler<GetBookDetailsQuery, BookDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public GetBookDetailsQueryHandler(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task<BookDetailsDto> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
        {
            var bookDetails = await _bookRepository.GetByIdAsync(request.Id);

            var data = _mapper.Map<BookDetailsDto>(bookDetails);

            return data;
        }
    }
}
