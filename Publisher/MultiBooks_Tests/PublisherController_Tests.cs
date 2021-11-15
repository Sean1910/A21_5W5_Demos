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

namespace MultiBooks_Tests
{
  [TestFixture]
  public class SubjectController_Tests
  {
    private Mock<IUnitOfWork> _unitOfWork;
    private Mock<ISubjectRepository> _repositorySubject;
     private Mock<ILogger<SubjectController>> _logger;
    private SubjectController _subjectController;

    [SetUp]
    public void Setup()
    {
      _unitOfWork = new Mock<IUnitOfWork>();
     // _logger = new Mock<ILogger<PublisherController>.Object>();
      _subjectController = new SubjectController(_unitOfWork.Object);
    }

    [Test]
    public void AddPublisher_ModelStateInvalid_ReturnView()
    {
      _subjectController.ModelState.AddModelError("test", "test");

      //var result = _subjectController.Create(new Subject());

      //ViewResult viewResult = result as ViewResult;
      //Assert.AreEqual("Create", viewResult.ViewName);
    }



  }
}