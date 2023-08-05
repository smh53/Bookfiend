using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.BookQuote.Queries.GetAllBookQuotes
{
    public class GetAllBookQuotesQuery : IRequest<List<BookQuoteDto>>
    {
    }
}
