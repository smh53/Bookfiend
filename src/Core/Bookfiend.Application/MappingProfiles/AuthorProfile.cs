using Bookfiend.Application.Features.Author.Queries.GetAllAuthors;
using Bookfiend.Application.Features.Book.Queries.GetAllBooks;
using Bookfiend.Domain;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.MappingProfiles
{
    public class AuthorProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Author, AuthorDto>();
        }
    }
}
