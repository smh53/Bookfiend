using Bookfiend.Application.Contracts.Persistence;
using Bookfiend.Application.Exceptions;
using Bookfiend.Domain;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.Book.Commands.CreateBook;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;

    public CreateBookCommandHandler(IMapper mapper, IBookRepository bookRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
    }

    public async Task<Unit> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateBookCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if(!validationResult.IsValid)
           throw new BadRequestException("Invalid Book", validationResult);
        
        var newBook = _mapper.Map<Domain.Book>(request);
        await _bookRepository.CreateAsync(newBook);
        return Unit.Value;
    }
}
