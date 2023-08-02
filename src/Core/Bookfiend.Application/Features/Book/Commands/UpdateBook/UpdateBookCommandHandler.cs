using Bookfiend.Application.Contracts.Persistence;
using Bookfiend.Application.Exceptions;
using Bookfiend.Application.Features.Book.Commands.CreateBook;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.Book.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public UpdateBookCommandHandler(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBookCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid Book", validationResult);

            var bookUpdate = _mapper.Map<Domain.Book>(request);
            await _bookRepository.UpdateAsync(bookUpdate);

            return Unit.Value;
        }
    }
}
