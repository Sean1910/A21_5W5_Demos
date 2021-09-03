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
  public class AuthorDetailRepository : Repository<AuthorDetail>, IAuthorDetailRepository
  {
    private readonly CrazyBooksDbContext _db;

    public AuthorDetailRepository(CrazyBooksDbContext db) : base(db)
    {
      _db = db;
    }

    public void Update(AuthorDetail authorDetail)
    {
      _db.Update(authorDetail);
    }
  }
}
