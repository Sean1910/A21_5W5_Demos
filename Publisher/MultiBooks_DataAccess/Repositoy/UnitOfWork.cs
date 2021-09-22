using MultiBooks_DataAccess.Data;
using MultiBooks_DataAccess.Repositoy.IRepository;
using MultiBooks_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBooks_DataAccess.Repositoy
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly MultiBooksDbContext _db;

    public UnitOfWork(MultiBooksDbContext db)
    {
      _db = db;

      Author = new AuthorRepository(_db);
      AuthorBook = new AuthorBookRepository(_db);
      AuthorDetail = new AuthorDetailRepository(_db);
      Book = new BookRepository(_db);
      Publisher = new PublisherRepository(_db);
      Subject = new SubjectRepository(_db);
    }

    public IAuthorRepository Author { get; private set; }
    public IAuthorBookRepository AuthorBook { get; private set; }
    public IAuthorDetailRepository AuthorDetail { get; private set; }
    public IBookRepository Book { get; private set; }
    public IPublisherRepository Publisher { get; private set; }
    public ISubjectRepository Subject { get; private set; }

    public void Dispose()
    {
      _db.Dispose();
    }

    public void Save()
    {
      _db.SaveChanges();
    }
  }
}
