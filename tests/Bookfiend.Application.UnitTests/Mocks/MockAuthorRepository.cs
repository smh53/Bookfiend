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
            new Author { Id = 1,Firstname = "Test", Lastname = "Authors" },
            new Author { Id = 2, Firstname = "Test", Lastname = "Authorx" },
            new Author { Id = 3, Firstname = "Test", Lastname = "Authory" },
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
