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
        public int Volume { get; set; }
        public string Printary { get; set; } = string.Empty;
        public DateTime PublishDate { get; set; }
        public string AuthorFirstname { get; set; } = string.Empty;
        public string AuthorLastname { get; set; } = string.Empty;
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
