using Bookfiend.Application.Contracts.Persistence;
using Bookfiend.Application.Features.Author.Queries.GetAllAuthors;
using Bookfiend.Application.MappingProfiles;
using Bookfiend.Application.UnitTests.Mock;
using Mapster;
using Mapster.Adapters;
using MapsterMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.UnitTests.Features.Authors.Queries
{
    public class GetAllAuthorsQueryHandlerTests
    {
        private readonly Mock<IAuthorRepository> _mockRepo;
        private readonly IMapper _mapper;

        public GetAllAuthorsQueryHandlerTests()
        {
            _mockRepo = MockAuthorRepository.GetMockAuthorRepository();



            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            var mapsterMapper = new Mapper(config);
            _mapper = mapsterMapper;

        }

        [Fact]
        public async Task GetAllAuthorsTest()
        {
            var handler = new GetAllAuthorsQueryHandler(_mapper, _mockRepo.Object);
            var result = await handler.Handle(new GetAllAuthorsQuery(), CancellationToken.None);
            result.ShouldBeOfType<List<AuthorDto>>();
            result.ShouldNotBeNull();
            result.Count.ShouldBe(3);
        }
    }
}
