using Bookfiend.Application.Contracts.Persistence;
using Bookfiend.Application.Exceptions;
using Bookfiend.Application.Features.Book.Commands.DeleteBook;
using Bookfiend.Application.MessageBroker;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.Author.Commands.DeleteAuthor
{
    internal class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, Unit>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IRabbitMqPublisher _rabbitMqPublisher;

        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository, IRabbitMqPublisher rabbitMqPublisher)
        {
            _authorRepository = authorRepository;
            _rabbitMqPublisher = rabbitMqPublisher;
        }

        public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {          
            var author = await _authorRepository.GetByIdAsync(request.Id);
            if (author is null)
                throw new NotFoundException(nameof(Domain.Author), request.Id);
            await _authorRepository.DeleteAsync(author);

            _rabbitMqPublisher.Publish(author);
            return Unit.Value;
        }
    }
}
