using Bookfiend.BlazorUI.Contracts;
using Bookfiend.BlazorUI.Services.Base;

namespace Bookfiend.BlazorUI.Services
{
    public class BookService : BaseHttpService, IBookService
    {
        public BookService(IClient client) : base(client)
        {
        }
    }
}
