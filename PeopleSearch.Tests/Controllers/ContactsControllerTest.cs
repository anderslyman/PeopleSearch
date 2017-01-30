using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PeopleSearch.Controllers;
using PeopleSearch.Models;
using PeopleSearch.Pocos;
using PeopleSearch.Services.Interfaces;

namespace PeopleSearch.Tests.Controllers
{
    [TestClass]
    public class ContactsControllerTest
    {
        [TestMethod]
        public void Search()
        {
            // Arrange
            var settingsService = new Mock<IContactService>();
            var contacts = new List<Contact> { new Contact() };
            settingsService.Setup(s => s.SearchContacts(It.IsAny<string>())).Returns(() => contacts);
            var controller = new ContactsController(settingsService.Object);

            // Act
            var result = controller.Search(new Payload {Text="search"});

            // Assert
            Assert.IsNotNull(result);
        }
    }
}