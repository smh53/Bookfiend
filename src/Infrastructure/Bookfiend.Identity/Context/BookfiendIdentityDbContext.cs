using Bookfiend.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Identity.Context
{
    public class BookfiendIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public BookfiendIdentityDbContext(DbContextOptions<BookfiendIdentityDbContext> options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(BookfiendIdentityDbContext).Assembly);
        }
    }
}
