﻿using Bookfiend.Application.Features.Book.Queries.GetAllBooks;
using Bookfiend.Application.Features.BookQuote.Queries.GetAllBookQuotes;
using Bookfiend.Domain;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.MappingProfiles
{
    public class BookQuoteProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<BookQuote, BookQuoteDto>()
             .Map(dest => dest.Book, src => src.Book);
            
        }
    }
}
