using Bookfiend.BlazorUI.Contracts;
using Bookfiend.BlazorUI.Models.Authors;
using Bookfiend.BlazorUI.Services.Base;
using Bookfiend.Domain;
using MapsterMapper;

namespace Bookfiend.BlazorUI.Services
{
    public class AuthorService : BaseHttpService, IAuthorService
    {
        private readonly IMapper _mapper;

        public AuthorService(IClient client, IMapper mapper) : base(client)
        {
            _mapper = mapper;
        }

        public async Task<Response<Guid>> CreateAuthor(AuthorVM author)
        {
            try
            {
                var createAuthorCommand = _mapper.Map<CreateAuthorCommand>(author);
                await _client.AuthorsPOSTAsync(createAuthorCommand);
                return new Response<Guid>();
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<Response<Guid>> DeleteAuthor(int id)
        {
            try
            {  
                await _client.AuthorsDELETEAsync(id);
                return new Response<Guid>() { Success = true};
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<List<AuthorVM>> GetAllAuthors()
        {
            var authors =await _client.AuthorsAllAsync();
            return _mapper.Map<List<AuthorVM>>(authors);

        }

        public async Task<AuthorVM> GetAuthorDetails(int id)
        {
            var author =await _client.AuthorsGETAsync(id);
            return _mapper.Map<AuthorVM>(author);
        }

        public async Task<Response<Guid>> UpddateAuthor(int id, AuthorVM author)
        {
            try
            {
                var updateAuthorCommand = _mapper.Map<UpdateAuthorCommand>(author);
                await _client.AuthorsPUTAsync(id.ToString(),updateAuthorCommand);
                return new Response<Guid>() { Success = true};
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
