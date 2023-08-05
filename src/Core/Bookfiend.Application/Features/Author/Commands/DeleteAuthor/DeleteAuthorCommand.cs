using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.Author.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
