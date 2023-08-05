using Bookfiend.Domain;

namespace Bookfiend.Application.Contracts.Persistence
{
    public interface IBookQuoteRepository : IGenericRepository<BookQuote>
    {
       Task<List<BookQuote>> GetAllBookQuotesWithBooksAndTheirAuthors();
    }
}
