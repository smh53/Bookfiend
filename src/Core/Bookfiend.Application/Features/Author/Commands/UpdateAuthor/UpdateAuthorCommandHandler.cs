using Bookfiend.Application.Contracts.Persistence;
using Bookfiend.Application.Exceptions;
using Bookfiend.Application.Features.Book.Commands.UpdateBook;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.Author.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;

        public UpdateAuthorCommandHandler(IMapper mapper, IAuthorRepository authorRepository)
        {
            _mapper = mapper;
            _authorRepository = authorRepository;
        }

        public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAuthorCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid Book", validationResult);

            var authorUpdate = _mapper.Map<Domain.Author>(request);
            await _authorRepository.UpdateAsync(authorUpdate);

            return Unit.Value;
        }
    }
}
