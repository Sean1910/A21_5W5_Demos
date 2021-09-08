﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CrazyBook_Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyBook.Areas.Admin.Controllers
{
  [Area("Admin")]
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      return View();
    }
  
  }
}
