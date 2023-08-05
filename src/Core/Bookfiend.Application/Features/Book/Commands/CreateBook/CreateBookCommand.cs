using Bookfiend.Application.Features.Book.Queries.GetAllBooks;
using Bookfiend.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.Book.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<Unit>
    {
        public string Name { get; set; } = string.Empty;
        public int Volume { get; set; }
        public int AuthorId { get; set; }
        public string Printary { get; set; } = string.Empty;
        public int PublishYear { get; set; }
        public ICollection<Domain.BookQuote>? BookQuotes { get; set; }
    }
    
}
