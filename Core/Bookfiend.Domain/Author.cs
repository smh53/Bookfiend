using Bookfiend.Domain.Common;

namespace Bookfiend.Domain;

public class Author : BaseEntity
{
 
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public ICollection<Book> Books { get; set; } = null!;
}
