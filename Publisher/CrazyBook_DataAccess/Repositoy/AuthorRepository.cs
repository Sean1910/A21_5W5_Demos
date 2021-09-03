using CrazyBook_DataAccess.Data;
using CrazyBook_DataAccess.Repositoy.IRepository;
using CrazyBook_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyBook_DataAccess.Repositoy
{
  public class AuthorRepository : Repository<Author>, IAuthorRepository
  {
    private readonly CrazyBooksDbContext _db;

    public AuthorRepository(CrazyBooksDbContext db) : base(db)
    {
      _db = db;
    }

    public void Update(Author author)
    {
      var dataFromDb = _db.Author.FirstOrDefault(s => s.Id == author.Id);

      if (dataFromDb != null)
      {
        dataFromDb.FirstName = author.FirstName;
        dataFromDb.LastName = author.LastName;
      }

     }
  }
}
