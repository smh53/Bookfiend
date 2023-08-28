using Bookfiend.Application.Contracts.Persistence;
using Bookfiend.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.UnitTests.Mock;

public static class MockAuthorRepository
{
    public static Mock<IAuthorRepository> GetMockAuthorRepository()
    {
        var mockRepo = new Mock<IAuthorRepository>();

        var authors = new List<Author>
        {
            new Author { Id = 1,FirstName = "Test", LastName = "Authors" },
            new Author { Id = 2, FirstName = "Test", LastName = "Authorx" },
            new Author { Id = 3, FirstName = "Test", LastName = "Authory" },
        };
       

        mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(authors);
        mockRepo.Setup(r => r.CreateAsync(It.IsAny<Author>())).Returns((Author author) =>
        {
            authors.Add(author);
            return Task.CompletedTask;
        });

        return mockRepo;
    }
}
