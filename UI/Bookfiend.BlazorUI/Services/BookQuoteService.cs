using Bookfiend.BlazorUI.Contracts;
using Bookfiend.BlazorUI.Services.Base;

namespace Bookfiend.BlazorUI.Services
{
    public class BookQuoteService : BaseHttpService, IBookQuoteService
    {
        public BookQuoteService(IClient client) : base(client)
        {
        }
    }
}
