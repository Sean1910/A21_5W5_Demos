using Microsoft.EntityFrameworkCore;
using MultiBooks_DataAccess.Data;
using MultiBooks_DataAccess.Repositoy;
using MultiBooks_Models;
using NUnit.Framework;
using System;

namespace MultiBooks_DataAccess
{
  [TestFixture]
  public class BookRepository_Tests
  {
    private Book book_One;
    private Book book_Two;
    private DbContextOptions<MultiBooksDbContext> options;
    
    public BookRepository_Tests()
    {
      book_One = new Book()
      {
        Id = 1,
        Title = @"De la supervision à la gestion",
        ISBN = "9782765076797",
        Price = 73.95,
        Subject_Id = 6,
        Publisher_Id = 2,
        PublishedDate = new DateTime(2015, 05, 01, 00, 00, 00),
        Available = true
      };

      book_Two = new Book()
      {
        Id = 2,
        Title = @"Merlin: la flamme éternelle",
        ISBN = "9782897869205",
        Price = 14.95,
        Subject_Id = 3,
        Publisher_Id = 3,
        PublishedDate = new DateTime(2020, 09, 01, 00, 00, 00),
        Available = true
      };
    }

    [SetUp]
    public void Setup()
    {
      options = new DbContextOptionsBuilder<MultiBooksDbContext>()
               .UseInMemoryDatabase(databaseName: "memory_MultiBooks").Options;
    }

    [Test]
    public void DeleteBook_BookAvailable_CheckAvailableFalseFDB()
    {
      //arrange
      using (var context = new MultiBooksDbContext(options))
      {
        context.Database.EnsureDeleted();
        var unitOfWork = new UnitOfWork(context);
        unitOfWork.Book.AddAsync(book_One);
        unitOfWork.Save();
      }

      //act
      using (var context = new MultiBooksDbContext(options))
      {
        var unitOfWork = new UnitOfWork(context);
        unitOfWork.Book.RemoveAsync(1);
        unitOfWork.Save();
      }

      //assert
      using (var context = new MultiBooksDbContext(options))
      {
        var BookFBD = context.Book.FirstOrDefaultAsync(b => b.Id == 1);
        Assert.AreEqual(book_One.Id, BookFBD.Result.Id);
        Assert.AreEqual(book_One.Title, BookFBD.Result.Title);
        Assert.AreNotEqual(book_One.Available, BookFBD.Result.Available);

        Assert.AreEqual(false, BookFBD.Result.Available);
      }
    }

    [Test]
    public void AddAsync_BookTwo_CheckValueFDB()
    {
      //arrange
      

      //act
      using (var context = new MultiBooksDbContext(options))
      {
        context.Database.EnsureDeleted();
        var unitOfWork = new UnitOfWork(context);
        unitOfWork.Book.AddAsync(book_Two);
        unitOfWork.Save();
      }

      //assert
      using (var context = new MultiBooksDbContext(options))
      {
        var BookFBD = context.Book.FirstOrDefaultAsync(b => b.Id == 2);
        Assert.AreEqual(book_Two.Id, BookFBD.Result.Id);
        Assert.AreEqual(book_Two.Title, BookFBD.Result.Title);

        
      }
    }

  }
}
