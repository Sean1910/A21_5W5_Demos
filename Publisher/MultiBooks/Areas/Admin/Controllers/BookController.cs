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
using Microsoft.AspNetCore.Hosting;
using MultiBooks_Utility;
using System.IO;

namespace MultiBooks.Areas.Admin.Controllers
{
  [Area("Admin")]
  public class BookController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<BookController> _logger;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public BookController(IUnitOfWork unitOfWork, ILogger<BookController> logger, IWebHostEnvironment webHostEnvironment)
    {
      _unitOfWork = unitOfWork;
      _logger = logger;
      _webHostEnvironment = webHostEnvironment;
    }
    public async Task<IActionResult> Index()
    {
      IEnumerable<Book> bookList = await _unitOfWork.Book.GetAllAsync(includeProperties: "Publisher,Subject");

      return View(bookList);
    }

    //GET UPSERT
    public async Task<IActionResult> Upsert(int? id)
    {
      IEnumerable<Subject> SubList = await _unitOfWork.Subject.GetAllAsync();

      IEnumerable<Publisher> PubList = await _unitOfWork.Publisher.GetAllAsync();

      BookVM bookVM = new BookVM()
      {
        Book = new Book(),
        SubjectList = SubList.Select(i => new SelectListItem
        {
          Text = i.Name,
          Value = i.Id.ToString()
        }),
        PublisherList = PubList.Select(i => new SelectListItem
        {
          Text = i.Name,
          Value = i.Id.ToString()
        })
      };
      if (id == null)
      {
        //CREATE
        return View(bookVM);
      }
      else
      {
        //EDIT
        bookVM.Book = await _unitOfWork.Book.GetFirstOrDefaultAsync(b => b.Id == id);
        if (bookVM == null)
        {
          return NotFound();
        }
        return View(bookVM);

      }
    }

    //POST UPSERT
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Upsert(BookVM bookVM)
    {
      if (ModelState.IsValid)//validation côté serveur
      {
        var files = HttpContext.Request.Form.Files; //nouvelle image récupérée
        string webRootPath = _webHostEnvironment.WebRootPath; //Chemin des images zombies

        // Update
        if (bookVM.Book.Id == 0)
        {
          //Insert  
          string upload = webRootPath + AppConst.ImagePathBooks; //ServeurProjet + la constante du chemin relatif
          string fileName = Guid.NewGuid().ToString(); //Récupérer le nom du fichier
          string extension = Path.GetExtension(files[0].FileName);//extraire l'extension (pour Nom fichier complet)

          // Créer le nouveau fichier dans le dossier upload
          using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
          {
            files[0].CopyTo(fileStream);
          }

          //Update l'image dans le form
          // seulement nom du fichier avec l'extension pas le path
          bookVM.Book.Cover = fileName + extension;

          await  _unitOfWork.Book.AddAsync(bookVM.Book); //Ajouter dans la BD
        }
        else
        {
          //Update
          var objFromDb = await _unitOfWork.Book.GetFirstOrDefaultAsync(b => b.Id == bookVM.Book.Id);
          if (files.Count > 0)
          {
            string upload = webRootPath + AppConst.ImagePathBooks;
            string fileName = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(files[0].FileName);

            var oldFile = Path.Combine(upload, objFromDb.Cover);

            if (System.IO.File.Exists(oldFile))
            {
              System.IO.File.Delete(oldFile);
            }

            using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
            {
              files[0].CopyTo(fileStream);
            }

            bookVM.Book.Cover = fileName + extension;
          }
          else
          {
            bookVM.Book.Cover = objFromDb.Cover;
          }

          _unitOfWork.Book.Update(bookVM.Book);
        }

        _unitOfWork.Save();
        return RedirectToAction(nameof(Index));
      }

      return View(bookVM);
    }


  
    [HttpPost]
    public IActionResult ManageAuthors(AuthorsBooksVM authorsBooksVM)
    {
      if (authorsBooksVM.AuthorBook.Book_Id != 0 && authorsBooksVM.AuthorBook.Author_Id != 0)
      {
        _unitOfWork.AuthorBook.AddAsync(authorsBooksVM.AuthorBook);
        _unitOfWork.Save();
      }
      return RedirectToAction(nameof(ManageAuthors), new { @id = authorsBooksVM.AuthorBook.Book_Id });
    }


  }
}
