using Bookfiend.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.Book.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual Domain.Author? Author { get; set; }
        public int AuthorId { get; set; }       
        public int PublishYear { get; set; }
        public ICollection<UpdateBookQuotesWithBookDto>? BookQuotes { get; set; }
    }
}
