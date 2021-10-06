using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MultiBooks_DataAccess.Repositoy.IRepository;
using MultiBooks_Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MultiBooks.Areas.Customer.Controllers
{
  [Area("Customer")]
  public class HomeController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<HomeController> _logger;

    public HomeController(IUnitOfWork unitOfWork, ILogger<HomeController> logger)
    {
      _unitOfWork = unitOfWork;
      _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
      IEnumerable<Book> bookList = await _unitOfWork.Book.GetAllAvailableAsync();

      return View(bookList);
    }

    public IActionResult Privacy()
    {
      return View();
    }

  
  }
}
