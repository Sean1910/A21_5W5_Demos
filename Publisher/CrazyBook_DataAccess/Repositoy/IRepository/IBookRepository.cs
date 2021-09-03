using CrazyBook_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyBook_DataAccess.Repositoy.IRepository
{
  public interface IBookRepository:IRepository<Book>
  {
    void Update(Book book);
  }
}
