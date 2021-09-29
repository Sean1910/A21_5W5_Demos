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
  public class SubjectRepository : RepositoryAsync<Subject>, ISubjectRepository
  {
    private readonly MultiBooksDbContext _db;

    public SubjectRepository(MultiBooksDbContext db) : base(db)
    {
      _db = db;
    }

    public void Update(Subject subject)
    {
      _db.Update(subject);
    }
  }
}
