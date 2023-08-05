using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.BookQuote.Commands.UpdateBookQuote
{
    public class UpdateBookQuoteCommand : IRequest<Unit>
    {
        public string Quote { get; set; } = string.Empty;
        public int BookId { get; set; }
        public int PageNumber { get; set; }
    }
}
