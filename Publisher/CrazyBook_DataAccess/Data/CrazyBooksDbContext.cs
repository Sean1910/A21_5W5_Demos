using CrazyBook_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyBook_DataAccess.Data
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
    public DbSet<Subject> Subject { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //Configuration fluent API

      //composite key
      modelBuilder.Entity<AuthorBook>().HasKey(ba => new { ba.Author_Id, ba.Book_Id });

      //Création d'un index unique (sans doublon)
      modelBuilder.Entity<Book>().HasIndex(b => b.ISBN).IsUnique();

      //Création d'un index composé, nom spécifié
      modelBuilder.Entity<Book>().HasIndex(b => new { b.Title, b.PublishedDate }).HasDatabaseName("Index_BookTitlePubDate");
    }
  }
}
