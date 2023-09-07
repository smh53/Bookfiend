using Bookfiend.Application.Contracts.Persistence;
using Bookfiend.Application.Exceptions;
using Bookfiend.Application.Features.Book.Commands.CreateBook;
using Bookfiend.Application.MessageBroker;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.Author.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
     


        public CreateAuthorCommandHandler(IMapper mapper, IAuthorRepository authorRepository)
        {
            _mapper = mapper;
            _authorRepository = authorRepository;
          
        }

        public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {          
            var newAuthor = _mapper.Map<Domain.Author>(request);
            var createdAuthorId =  await _authorRepository.CreateAsync(newAuthor);
         
            return createdAuthorId;
        }
    }
}
