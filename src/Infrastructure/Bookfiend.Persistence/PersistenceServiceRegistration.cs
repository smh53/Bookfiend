using Bookfiend.Application.Contracts.Persistence;
using Bookfiend.Persistence.DatabaseContext;
using Bookfiend.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookfiendDatabaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("BookfiendConnectionString"));
            });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookQuoteRepository, BookQuoteRepository>();
            return services;
        }
    }
}
