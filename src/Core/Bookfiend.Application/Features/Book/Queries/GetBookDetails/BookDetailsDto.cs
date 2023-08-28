using Bookfiend.Application.Features.Author.Queries.GetAllAuthors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.Features.Book.Queries.GetBookDetails
{
    public class BookDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int PublishYear { get; set; }
       
        public AuthorDto Author { get; set; } = null;
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
