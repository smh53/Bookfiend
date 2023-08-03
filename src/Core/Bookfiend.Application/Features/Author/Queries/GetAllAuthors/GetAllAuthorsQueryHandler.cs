using Bookfiend.Application.Contracts.Persistence;
using Bookfiend.Application.Features.Book.Queries.GetAllBooks;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.Author.Queries.GetAllAuthors
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, List<AuthorDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;

        public GetAllAuthorsQueryHandler(IMapper mapper, IAuthorRepository authorRepository)
        {
            _mapper = mapper;
            _authorRepository = authorRepository;
        }
        public async Task<List<AuthorDto>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = await _authorRepository.GetAsync();

            var data = _mapper.Map<List<AuthorDto>>(authors);

            return data;
        }
    }
}
