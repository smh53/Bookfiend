using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.BookQuote.Queries.GetAllBookQuotes
{
    public class BookQuoteDto
    {
        public string Quote { get; set; } = string.Empty;
        public string BookName { get; set; } = string.Empty;
        public string BookAuthorFirstname { get; set; } = string.Empty;
        public string BookAuthorLastname { get; set; } = string.Empty;
        public int PageNumber { get; set; }
    }
}
