using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.Book.Queries.GetBookDetails
{
    public record GetBookDetailsQuery(int Id) : IRequest<BookDetailsDto>;
    
}
