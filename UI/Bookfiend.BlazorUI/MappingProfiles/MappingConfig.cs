using Bookfiend.BlazorUI.Models.Authors;
using Bookfiend.BlazorUI.Services.Base;
using Mapster;

namespace Bookfiend.BlazorUI.MappingProfiles
{
    public class MappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AuthorDto, AuthorVM>();
            config.NewConfig<CreateAuthorCommand, AuthorVM>();
            config.NewConfig<UpdateAuthorCommand, AuthorVM>();
        }
    }
}
