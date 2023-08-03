using Bookfiend.Application.Contracts.Persistence;
using Bookfiend.Application.Features.Book.Queries.GetAllBooks;
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
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
      
        public BookRepository(BookfiendDatabaseContext context) : base(context)
        {
           
        }

        public async Task<List<Book>> GetAllBooksWithAuthors()
        {
            return await _dbContext.Books.Include(f => f.Author).ToListAsync();
        }
    }
}
