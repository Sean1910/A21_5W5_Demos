using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrazyBook.Models;
using CrazyBook.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrazyBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrazyBook.Areas.Admin.Controllers
{
  [Area("Admin")]
  public class BookController : Controller
  {
    private readonly CrazyBooksDbContext _db;

    public BookController(CrazyBooksDbContext db)
    {
      _db = db;
    }


    public IActionResult Index()
    {
      //Sans Repository Patterns: Redéfini à chaque fois
      List<Book> objList = _db.Book.Include(u => u.Publisher)
                                   .Include(u => u.AuthorsBooks).ThenInclude(u => u.Author).ToList();
      return View(objList);
    }

    public IActionResult Create()
    {
      BookVM obj = new BookVM();
      obj.PublisherList = _db.Publisher.Select(i => new SelectListItem
      {
        Text = i.Name,
        Value = i.Id.ToString()
      });
            
      return View(obj);
    }

    public IActionResult Update(int? id)
    {
      BookVM obj = new BookVM();
      obj.PublisherList = _db.Publisher.Select(i => new SelectListItem
      {
        Text = i.Name,
        Value = i.Id.ToString()
      });
     
       obj.Book = _db.Book.FirstOrDefault(u => u.Id == id);
      if (obj == null)
      {
        return NotFound();
      }
      return View(obj);
    }
  }
}
