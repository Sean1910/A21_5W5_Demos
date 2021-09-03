using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyBook.Models.Data
{
  public class CrazyBooksDbContext:DbContext
  {
    public CrazyBooksDbContext(DbContextOptions<CrazyBooksDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Book { get; set; }
    public DbSet<Author> Author { get; set; }
    public DbSet<Publisher> Publisher { get; set; }
    public DbSet<AuthorBook> AuthorBook { get; set; }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //Configuration fluent API

      //composite key
      modelBuilder.Entity<AuthorBook>().HasKey(ba => new { ba.Author_Id, ba.Book_Id });
    }
  }
}
