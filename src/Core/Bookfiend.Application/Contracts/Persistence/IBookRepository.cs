using Bookfiend.Application.Features.Book.Queries.GetAllBooks;
using Bookfiend.Domain;

namespace Bookfiend.Application.Contracts.Persistence
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<List<Book>> GetAllBooksWithAuthors(); 
    }
}
