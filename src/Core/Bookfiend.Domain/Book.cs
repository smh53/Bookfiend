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
    public virtual Author? Author { get; set; }
    public int AuthorId { get; set; }
    public int PublishYear { get; set; }
    public ICollection<BookQuote>? BookQuotes { get; set; } 

}
