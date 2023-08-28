using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.Book.Commands.UpdateBook
{
    public class UpdateBookQuotesWithBookDto
    {
        public string Quote { get; set; } = string.Empty;
        public int PageNumber { get; set; }
    }
}
