using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MultiBooks_DataAccess.Repositoy.IRepository;
using MultiBooks_Models;
using MultiBooks_Models.ViewModels;
using MultiBooks_Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MultiBooks.Areas.Authors.Controllers
{
  [Area("Authors")]
  public class AuthorController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<AuthorController> _logger;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public AuthorController(IUnitOfWork unitOfWork, ILogger<AuthorController> logger, IWebHostEnvironment webHostEnvironment)
    {
      _unitOfWork = unitOfWork;
      _logger = logger;
      _webHostEnvironment = webHostEnvironment;
    }

    public async Task<IActionResult> Index()
    {
      IEnumerable<Author> AuthorList = await _unitOfWork.Author.GetAllAsync();

      return View(AuthorList);
    }

    //GET - UPSERT
    public async Task<IActionResult> Upsert(int? id)
    {
      AuthorVM authorVM = new AuthorVM()
      {
        Author = new Author()
      };

      if (id == null)
      {
        //CREATE
        return View(authorVM);
      }
      else
      {
        //EDIT
        authorVM.Author = await _unitOfWork.Author.GetFirstOrDefaultAsync(filter: a => a.Id == id, includeProperties: "AuthorDetail");

        if (authorVM == null)
        {
          return NotFound();
        }
        return View(authorVM);
      }

    }

    //POST Upsert
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Upsert(AuthorVM authorVM)
    {
      if (ModelState.IsValid)
      {
        var files = HttpContext.Request.Form.Files; //nouveau fichier récupéré
      string webRootPath = _webHostEnvironment.WebRootPath; //Chemin jusqu'au Root (pour les fichiers)

      if (authorVM.Author.Id == 0)
      {
        //Insert
        string upload = webRootPath + AppConst.ImagePathAuthors; //ServeurProjet + la constante du chemin relatif
        string fileName = Guid.NewGuid().ToString(); //Récupérer le nom du fichier
        string extension = Path.GetExtension(files[0].FileName);//extraire l'extension (pour Nom fichier complet)

        // Créer le nouveau fichier dans le dossier upload
        using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
        {
          files[0].CopyTo(fileStream);
        }

        //Update l'image dans le form
        // seulement nom du fichier avec l'extension pas le path
        authorVM.Author.AuthorDetail.Photo = fileName + extension;

        await _unitOfWork.Author.AddAsync(authorVM.Author);
        await _unitOfWork.AuthorDetail.AddAsync(authorVM.Author.AuthorDetail);
      }
      else
      {
        //Update
        var objFromDb = await _unitOfWork.Author.GetFirstOrDefaultAsync(a => a.Id == authorVM.Author.Id);
        if (files.Count > 0)
        {
          string upload = webRootPath + AppConst.ImagePathAuthors;
          string fileName = Guid.NewGuid().ToString();
          string extension = Path.GetExtension(files[0].FileName);

          if (authorVM.Photo != null)
          {
            var oldFile = Path.Combine(upload, objFromDb.AuthorDetail.Photo);

            if (System.IO.File.Exists(oldFile))
            {
              System.IO.File.Delete(oldFile);
            }
          }
          using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
          {
            files[0].CopyTo(fileStream);
          }

          authorVM.Author.AuthorDetail.Photo = fileName + extension;
        }
        else
        {
          authorVM.Author.AuthorDetail.Photo = objFromDb.AuthorDetail.Photo;
        }

        _unitOfWork.Author.Update(authorVM.Author);
        _unitOfWork.AuthorDetail.Update(authorVM.Author.AuthorDetail);

        _unitOfWork.Save();
        return RedirectToAction(nameof(Index));
      }
    }
     return View(authorVM);
  }


    //GET DELETE
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null || id == 0)
      {
        return NotFound();
      }

      var obj = await _unitOfWork.Author.GetAsync(id.GetValueOrDefault());
      if (obj == null)
      {
        return NotFound();
      }

      return View(obj);
    }

    //POST DELETE
    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> DeletePost(int? id)
    {
      var obj = await _unitOfWork.Author.GetAsync(id.GetValueOrDefault());
      if (obj == null)
      {
        return NotFound();
      }

      await _unitOfWork.Author.RemoveAsync(obj);
      _unitOfWork.Save();

      return RedirectToAction("Index");
    }
  }
}
