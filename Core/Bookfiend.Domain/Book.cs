using Bookfiend.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Domain;

public class Book : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public virtual Author Author { get; set; } = null!;
    public int AuthorId { get; set; }
    public int Volume { get; set; }
    public string Printary { get; set; } = string.Empty;
    public DateTime PublishDate { get; set; }
    public ICollection<BookQuote>? BookQuotes { get; set; } 

}
