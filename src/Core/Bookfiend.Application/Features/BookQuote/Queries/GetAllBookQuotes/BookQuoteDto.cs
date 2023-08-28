using Bookfiend.Application.Features.Book.Queries.GetAllBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.BookQuote.Queries.GetAllBookQuotes
{
    public class BookQuoteDto
    {
        public int Id { get; set; }
        public string Quote { get; set; } = string.Empty;
        public BookDto? Book { get; set; }
        public int PageNumber { get; set; }
    }
}
