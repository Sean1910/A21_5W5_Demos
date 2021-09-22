using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiBooks_Models;
using MultiBooks_DataAccess.Data;
using MultiBooks_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiBooks_DataAccess.Repositoy.IRepository;
using Microsoft.Extensions.Logging;

namespace MultiBooks.Areas.Admin.Controllers
{
  [Area("Admin")]
  public class BookController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<BookController> _logger;

    public BookController(IUnitOfWork unitOfWork, ILogger<BookController> logger)
    {
      _unitOfWork = unitOfWork;
      _logger = logger;
    }
    public IActionResult Index()
    {
      IEnumerable<Book> objList = _unitOfWork.Book.GetAll(includeProperties: "Publisher,Subject");

      return View(objList);
    }

    //GET CREATE
    public IActionResult Create()
    {
      BookVM bookVM = new BookVM()
      {
        Book = new Book(),
        SubjectList = _unitOfWork.Subject.GetAll().Select(i => new SelectListItem
        {
          Text = i.Name,
          Value = i.Id.ToString()
        }),
        PublisherList = _unitOfWork.Publisher.GetAll().Select(i => new SelectListItem
        {
          Text = i.Name,
          Value = i.Id.ToString()
        })
      };
      return View(bookVM);
    }

    //POST CREATE
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(BookVM bookVM)
    {
      if (ModelState.IsValid)
      {
        // Ajouter à la BD
        _unitOfWork.Book.Add(bookVM.Book);
      }

      _unitOfWork.Save();
      return RedirectToAction(nameof(Index));
    }
  }
}
