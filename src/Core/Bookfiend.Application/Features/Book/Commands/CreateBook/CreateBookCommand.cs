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
    public class CreateBookCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;      
        public int AuthorId { get; set; }
        public int PublishYear { get; set; }
        public ICollection<CreateBookQuotesWithBookDto>? BookQuotes { get; set; }
    }
    
}
