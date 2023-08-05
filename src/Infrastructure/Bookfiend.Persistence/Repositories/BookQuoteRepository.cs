using Bookfiend.Application.Contracts.Persistence;
using Bookfiend.Domain;
using Bookfiend.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Persistence.Repositories
{
    public class BookQuoteRepository : GenericRepository<BookQuote>, IBookQuoteRepository
    {
        public BookQuoteRepository(BookfiendDatabaseContext context) : base(context)
        {
            
        }

        public async Task<List<BookQuote>> GetAllBookQuotesWithBooksAndTheirAuthors()
        {
            return await _dbContext.BookQuotes.Include(f => f.Book).ThenInclude(f => f.Author).ToListAsync();
        }
    }
}
