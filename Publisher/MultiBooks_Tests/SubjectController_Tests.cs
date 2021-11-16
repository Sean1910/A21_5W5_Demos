using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MultiBooks.Areas.Publishers.Controllers;
using MultiBooks.Areas.Admin.Controllers;
using MultiBooks.Controllers;
using MultiBooks_DataAccess.Repositoy.IRepository;
using MultiBooks_Models;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace MultiBooks_Tests
{
  [TestFixture]
  public class SubjectController_Tests
  {
    private Mock<IUnitOfWork> _unitOfWork;
    private SubjectController _subjectController;

    [SetUp]
    public void Setup()
    {
      _unitOfWork = new Mock<IUnitOfWork>();
      _subjectController = new SubjectController(_unitOfWork.Object);
    }

    [Test]
    public void AddPublisher_ModelStateInvalid_ReturnView()
    {

      _subjectController.ModelState.AddModelError("Invalid", "Invalid");

      var actionResultTask = _subjectController.Create(new Subject());
      actionResultTask.Wait();
      var viewResult = actionResultTask.Result as ViewResult;

      // Assert
      Assert.NotNull(viewResult);
      Assert.AreEqual("Create", viewResult.ViewName);
    }



  }
}