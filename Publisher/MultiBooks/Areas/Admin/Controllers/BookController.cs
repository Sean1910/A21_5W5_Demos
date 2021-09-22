using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiBooks.Models;
using MultiBooks.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiBooks.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MultiBooks.Areas.Admin.Controllers
{
  [Area("Admin")]
  public class BookController : Controller
  {
    private readonly MultiBooksDbContext _db;

    public BookController(MultiBooksDbContext db)
    {
      _db = db;
    }


    public IActionResult Index()
    {
      //Sans Repository Patterns: Redéfini à chaque fois
      List<Book> objList = _db.Book.Include(u => u.Publisher)
                                   .Include(u => u.Subject).ToList();
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

    //POST CREATE
    [HttpPost]
    public IActionResult Create(Book book)
    {
      if (ModelState.IsValid)
      {
        // Ajouter à la BD
      }

      return this.View(book);
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
