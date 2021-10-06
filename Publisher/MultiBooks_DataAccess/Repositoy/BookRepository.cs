﻿using Microsoft.EntityFrameworkCore;
using MultiBooks_DataAccess.Data;
using MultiBooks_DataAccess.Repositoy.IRepository;
using MultiBooks_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiBooks_DataAccess.Repositoy
{
  public class BookRepository : RepositoryAsync<Book>, IBookRepository
  {
    private readonly MultiBooksDbContext _db;

    public BookRepository(MultiBooksDbContext db) : base(db)
    {
      _db = db;
    }

    public void Update(Book book)
    {
      _db.Update(book);
    }

    public async Task<IEnumerable<Book>> GetAllAvailableAsync()
    {
      return await base.GetAllAsync(filter: b => b.Available == true,  includeProperties: "Publisher,Subject");
    }

  }
}
