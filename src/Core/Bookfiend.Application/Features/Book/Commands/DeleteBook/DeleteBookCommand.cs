using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.Book.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<Unit>
    {
        public int Id { get; set; }

    }
}
