﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiBooks.Models.ViewModels
{
  public class BookVM
  {
    public Book Book { get; set; }
    public IEnumerable<SelectListItem> PublisherList { get; set; }
    public IEnumerable<SelectListItem> SubjectList { get; set; }
  }
}
