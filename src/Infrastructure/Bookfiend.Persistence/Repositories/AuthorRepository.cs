using Bookfiend.Application.Contracts.Persistence;
using Bookfiend.Domain;
using Bookfiend.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Persistence.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(BookfiendDatabaseContext context) : base(context)
        {
            
        }
    }
}
