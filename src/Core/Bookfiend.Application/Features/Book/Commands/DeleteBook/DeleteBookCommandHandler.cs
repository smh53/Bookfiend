using Bookfiend.Application.Contracts.Persistence;
using Bookfiend.Application.Exceptions;
using Bookfiend.Application.Features.Book.Commands.UpdateBook;
using Bookfiend.Domain;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.Book.Commands.DeleteBook;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
{
    private readonly IBookRepository _bookRepository;


    public DeleteBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;

    }

    public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {      
        var book = await _bookRepository.GetByIdAsync(request.Id);
        if(book is null) 
            throw new NotFoundException(nameof(Domain.Book), request.Id);
        await _bookRepository.DeleteAsync(book);
        return Unit.Value;
    }
}
