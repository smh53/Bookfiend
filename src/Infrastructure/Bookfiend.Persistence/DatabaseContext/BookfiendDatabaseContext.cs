using Bookfiend.Application.Contracts.Identity;
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
        private readonly IUserService _userService;

      

        public BookfiendDatabaseContext(DbContextOptions<BookfiendDatabaseContext> options, IUserService userService) : base(options)
        {
            _userService = userService;
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookQuote> BookQuotes { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
           foreach(var entry in base.ChangeTracker.Entries<BaseEntity>()
           .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.DateModified = DateTime.Now;
                entry.Entity.ModifiedBy = _userService.UserId;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                    entry.Entity.CreatedBy = _userService.UserId;
                }
                    
               
            }

           return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
