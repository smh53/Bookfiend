using Bookfiend.Domain;
using Bookfiend.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace Bookfiend.Persistence.IntegrationTests;

public class BookfiendDatabaseContextTests
{
    private BookfiendDatabaseContext _bookfiendDatabaseContext;

    public BookfiendDatabaseContextTests()
    {
        var dbOptions = new DbContextOptionsBuilder<BookfiendDatabaseContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

        _bookfiendDatabaseContext = new BookfiendDatabaseContext(dbOptions);

    }
    [Fact]
    public async void Save_SetDateCreatedValue()
    {
       // Arrange
        var author =  new Author { Id = 1, Firstname = "Test", Lastname = "Authors" };
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
        var author = new Author { Id = 1, Firstname = "Test", Lastname = "Authors" };
        // Act
        await _bookfiendDatabaseContext.Authors.AddAsync(author);
        await _bookfiendDatabaseContext.SaveChangesAsync();
        // Assert
        author.DateModified.ShouldNotBeNull();
    }
}