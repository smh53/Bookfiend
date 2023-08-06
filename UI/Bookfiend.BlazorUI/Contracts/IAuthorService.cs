using Bookfiend.BlazorUI.Models.Authors;
using Bookfiend.BlazorUI.Services.Base;

namespace Bookfiend.BlazorUI.Contracts
{
    public interface IAuthorService
    {
        Task<List<AuthorVM>> GetAllAuthors();
        Task<AuthorVM> GetAuthorDetails(int id);
        Task<Response<Guid>> CreateAuthor(AuthorVM author);
        Task<Response<Guid>> UpddateAuthor(int id, AuthorVM author);
        Task<Response<Guid>> DeleteAuthor(int id);

    }
}
