using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MultiBooks_DataAccess.Repositoy.IRepository;
using MultiBooks_DataAccess.Repositoy;
using MultiBooks_Models;
using MultiBooks_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiBooks.Areas.Publishers.Controllers
{
  [Area("Publishers")]
  public class PublisherController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<PublisherController> _logger;

    //public PublisherController(IUnitOfWork unitOfWork, ILogger<PublisherController> logger)
    public PublisherController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
     // _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
      IEnumerable<Publisher> PublisherList = await _unitOfWork.Publisher.GetAllAsync();

      return View(PublisherList);

    }

    public async Task<IActionResult> Detail(int id)
    {
      PublisherVM PublisherVM = new PublisherVM()
      {
        Publisher = await _unitOfWork.Publisher.GetFirstOrDefaultAsync(p => p.Id == id),
        BooksList = await _unitOfWork.Book.GetAllAsync(b => b.Publisher_Id == id, includeProperties: "Subject")

      };
      return View(PublisherVM);
    }
  }
}
