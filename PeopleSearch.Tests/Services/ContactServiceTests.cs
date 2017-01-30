using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleSearch.Models;
using PeopleSearch.Services.Implementations;

namespace PeopleSearch.Tests.Services
{
    [TestClass]
    public class ContactServiceTests
    {
        [TestMethod]
        public void SearchContacts()
        {
            // Arrange
            var tokens = new[]
            {
                new Contact { Name = "search a" },
                new Contact { Name = "search b" },
                new Contact { Name = "search c" },
                new Contact { Name = "d" },
            };

            var context = TestUtil.GetDataContextMock(tokens);
            var service = new ContactService(context.Object);

            // Act
            var contacts = service.SearchContacts("search");

            // Assert
            Assert.IsNotNull(contacts);
            Assert.AreEqual(3, contacts.Count);
        }

        [TestMethod]
        public void SearchContactsNull()
        {
            // Arrange
            var tokens = new[]
            {
                new Contact { Name = "d" },
            };

            var context = TestUtil.GetDataContextMock(tokens);
            var service = new ContactService(context.Object);

            // Act
            var contacts = service.SearchContacts(null);

            // Assert
            Assert.IsNotNull(contacts);
            Assert.AreEqual(0, contacts.Count);
        }
    }
}