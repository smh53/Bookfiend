using Bookfiend.Application.Features.Book.Queries.GetAllBooks;
using Bookfiend.Application.Features.Book.Queries.GetBookDetails;
using Bookfiend.Domain;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.MappingProfiles
{
    public class BookProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Book, BookDto>()
              .Map(dest => dest.Author, src => src.Author);
              

            config.NewConfig<Book, BookDetailsDto>()
               .Map(dest => dest.Author, src => src.Author);
             
        }
    }
}
