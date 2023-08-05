using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.Author.Queries.GetAuthorDetails
{
    public record GetAuthorDetailsQuery(int Id) : IRequest<AuthorDetailsDto>;
   
}
