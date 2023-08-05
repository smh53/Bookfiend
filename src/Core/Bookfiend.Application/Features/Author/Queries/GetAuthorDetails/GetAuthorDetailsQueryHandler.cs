using Bookfiend.Application.Contracts.Persistence;
using Bookfiend.Application.Features.Book.Queries.GetBookDetails;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.Author.Queries.GetAuthorDetails
{
    public class GetAuthorDetailsQueryHandler : IRequestHandler<GetAuthorDetailsQuery, AuthorDetailsDto>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAuthorDetailsQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorDetailsDto> Handle(GetAuthorDetailsQuery request, CancellationToken cancellationToken)
        {
            var authorDetails = await _authorRepository.GetByIdAsync(request.Id);

            var data = _mapper.Map<AuthorDetailsDto>(authorDetails);

            return data;
        }
    }
}
