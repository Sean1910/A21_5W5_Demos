using MultiBooks_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBooks_DataAccess.Repositoy.IRepository
{
  public interface IAuthorDetailRepository:IRepository<AuthorDetail>
  {
    void Update(AuthorDetail authorDetail);
  }
}
