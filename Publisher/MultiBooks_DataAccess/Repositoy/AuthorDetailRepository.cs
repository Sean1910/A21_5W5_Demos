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
  public class AuthorDetailRepository : RepositoryAsync<AuthorDetail>, IAuthorDetailRepository
  {
    private readonly MultiBooksDbContext _db;

    public AuthorDetailRepository(MultiBooksDbContext db) : base(db)
    {
      _db = db;
    }

    public void Update(AuthorDetail authorDetail)
    {
      _db.Update(authorDetail);
    }
  }
}
