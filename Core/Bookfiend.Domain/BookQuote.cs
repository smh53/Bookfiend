using Bookfiend.Domain.Common;

namespace Bookfiend.Domain;

public class BookQuote : BaseEntity
{
    public string Quote { get; set; } = string.Empty;
    public virtual Book Book { get; set; } = null!;
    public int BookId { get; set; }
    public int PageNumber { get; set; }
}
