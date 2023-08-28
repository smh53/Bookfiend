using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.Book.Commands.CreateBook
{
    public class CreateBookQuotesWithBookDto
    {
        public string Quote { get; set; } = string.Empty;     
        public int PageNumber { get; set; }
    }
}
