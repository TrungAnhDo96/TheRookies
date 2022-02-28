using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using RK_A7.Models;
using RK_A7.Controllers;
using RK_A7.Interfaces;

namespace RK_A7.Tests;

public class RK_A7_PeopleController
{
    private PeopleController _controller;
    private Mock<IPeopleService> _mockService;

    [SetUp]
    public void Setup()
    {
        _mockService = new Mock<IPeopleService>();
        var mockLogger = new Mock<ILogger<PeopleController>>();
        _controller = new PeopleController(mockLogger.Object, _mockService.Object);
    }

    [Test]
    public void Index_ReturnView()
    {
        //Act
        var result = _controller.Index();

        //Assert
        Assert.IsInstanceOf<ViewResult>(result);
    }

    [Test]
    public void Edit_ReturnRedirectToActionResult()
    {
        //Arrange
        var editPerson = new PersonModel() { Id = 1, FirstName = "Edited" };

        //Act
        var result = _controller.Edit(1, editPerson);

        //Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        Assert.AreEqual("Members", (result as RedirectToActionResult).ActionName);
    }

    [Test]
    public void Delete_ReturnRedirectToActionResult()
    {
        //Arrange
        var deletePersonId = 1;

        //Act
        var result = _controller.Delete(deletePersonId);

        //Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        Assert.AreEqual("DeleteConfirmation", (result as RedirectToActionResult).ActionName);
    }

    [Test]
    public void MemberDetails_ReturnView()
    {
        //Arrange
        var personId = 1;

        //Act
        var result = _controller.MemberDetails(personId);

        //Arrange
        Assert.IsInstanceOf<ViewResult>(result);
    }

    [Test]
    public void Members_ReturnView()
    {
        //Act
        var result = _controller.Members();

        //Arrange
        Assert.IsInstanceOf<ViewResult>(result);
    }
}