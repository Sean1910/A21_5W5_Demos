using MultiBooks_DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiBooks_DataAccess.Data;
using MultiBooks_DataAccess.Repositoy.IRepository;
using MultiBooks_Models;

namespace MultiBooks.Controllers
{
  [Area("Admin")]
  public class SubjectController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<SubjectController> _logger;

    public SubjectController(IUnitOfWork unitOfWork, ILogger<SubjectController> logger)
    {
      _unitOfWork = unitOfWork;
      _logger = logger;
    }
    public async Task<IActionResult> Index()
    {
      IEnumerable<Subject> SubjectList = await _unitOfWork.Subject.GetAllAsync();

      return View(SubjectList);
    }

    //GET CREATE
    public IActionResult Create()
    {
      return View();
    }

    //POST CREATE
    [HttpPost]
    public async Task<IActionResult> Create(Subject subject)
    {
      if (ModelState.IsValid)
      {
        // Ajouter à la BD
      await  _unitOfWork.Subject.AddAsync(subject);

        _unitOfWork.Save();
        return RedirectToAction(nameof(Index));
      }
      return this.View(subject);
    }

    // GET EDIT
    public async Task<IActionResult> Edit(int id)
    {
      Subject subject = new Subject();

      subject = await _unitOfWork.Subject.GetFirstOrDefaultAsync(s => s.Id == id);
      if (subject == null)
      {
        return NotFound();
      }
      return View(subject);
    }

    // POST EDIT
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Subject subject)
    {
      if (ModelState.IsValid)
      {
        _unitOfWork.Subject.Update(subject);
      
        _unitOfWork.Save();
        return RedirectToAction(nameof(Index));
      }
      return View(subject);
    }

    // DELETE
    public async Task<IActionResult> Delete(int id)
    {
      var objFromDb =await _unitOfWork.Subject.GetFirstOrDefaultAsync(u => u.Id == id);
      await _unitOfWork.Subject.RemoveAsync(objFromDb);
      _unitOfWork.Save();
      return RedirectToAction(nameof(Index));
    }

  }
}

