using Bookfiend.Domain;
using Bookfiend.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Persistence.DatabaseContext
{
    public class BookfiendDatabaseContext : DbContext
    {
        public BookfiendDatabaseContext(DbContextOptions<BookfiendDatabaseContext> options) : base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookQuote> BookQuotes { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
           foreach(var entry in base.ChangeTracker.Entries<BaseEntity>()
           .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.DateModified = DateTime.Now;

                if(entry.State == EntityState.Added)
                    entry.Entity.DateCreated = DateTime.Now;
               
            }
           return base.SaveChangesAsync(cancellationToken);
        }
    }
}
