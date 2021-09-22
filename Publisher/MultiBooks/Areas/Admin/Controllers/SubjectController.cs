using MultiBooks.Models;
using MultiBooks.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiBooks.Controllers
{
  [Area("Admin")]
  public class SubjectController : Controller
  {
    private readonly MultiBooksDbContext _db;
    private readonly ILogger<SubjectController> _logger;

    public SubjectController(MultiBooksDbContext db, ILogger<SubjectController> logger)
    {
      _db = db;
    }
    public IActionResult Index()
    {
      //Sans Repository Patterns: Redéfini à chaque fois
      List<Subject> objList = _db.Subject.ToList();

      return View(objList);
    }

    //GET CREATE
    public IActionResult Create()
    {
      return View();
    }

    //POST CREATE
    [HttpPost]
    public IActionResult Create(Subject subject)
    {
      if (ModelState.IsValid)
      {
        // Ajouter à la BD
      }

      return this.View(subject);
    }
  }
}
