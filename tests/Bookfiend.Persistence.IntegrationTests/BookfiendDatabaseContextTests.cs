using Bookfiend.Application.Contracts.Identity;
using Bookfiend.Domain;
using Bookfiend.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace Bookfiend.Persistence.IntegrationTests;

public class BookfiendDatabaseContextTests
{
    private readonly BookfiendDatabaseContext _bookfiendDatabaseContext;
    private readonly IUserService _userService;

    public BookfiendDatabaseContextTests(IUserService userService)
    {   _userService = userService;
        var dbOptions = new DbContextOptionsBuilder<BookfiendDatabaseContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

        _bookfiendDatabaseContext = new BookfiendDatabaseContext(dbOptions,_userService);

    }
    [Fact]
    public async void Save_SetDateCreatedValue()
    {
       // Arrange
        var author =  new Author { Id = 1, FirstName = "Test", LastName = "Authors" };
       // Act
        await _bookfiendDatabaseContext.Authors.AddAsync(author);
        await _bookfiendDatabaseContext.SaveChangesAsync();
       // Assert
        author.DateCreated.ShouldNotBeNull();
    }
    [Fact]
    public async void Save_SetDateModifiedValue()
    {
        // Arrange
        var author = new Author { Id = 1, FirstName = "Test", LastName = "Authors" };
        // Act
         _bookfiendDatabaseContext.Authors.Update(author);
        await _bookfiendDatabaseContext.SaveChangesAsync();
        // Assert
        author.DateModified.ShouldNotBeNull();
    }
}