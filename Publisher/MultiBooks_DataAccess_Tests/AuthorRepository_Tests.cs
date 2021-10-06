using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MultiBooks_DataAccess.Data;
using NUnit.Framework;

namespace MultiBooks_DataAccess_Tests
{
  [TestFixture]
  public class Tests
  {
   
    private DbContextOptions<MultiBooksDbContext> options;
    [SetUp]
    public void Setup()
    {
      //options = new DbContextOptionsBuilder<MultiBooksDbContext>()
      //         .UseInMemoryDatabase(databaseName: "memory_MultiBooks").Options;
    }

    [Test]
    public void Test1()
    {
      Assert.Pass();
    }
  }
}