using Bookfiend.Domain;
using System.ComponentModel.DataAnnotations;

namespace Bookfiend.BlazorUI.Models.Authors
{
    public class AuthorVM
    {
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public ICollection<Book> Books { get; set; } = null!;
    }
}
