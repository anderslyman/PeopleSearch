using System.Collections.Generic;
using System.Linq;
using PeopleSearch.Models;
using PeopleSearch.Services.Interfaces;

namespace PeopleSearch.Services.Implementations
{
    public class ContactService : IContactService
    {
        private readonly IDataContext _db;

        public ContactService(IDataContext db)
        {
            _db = db;
        }

        public List<Contact> SearchContacts(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return new List<Contact>();

            var words = text.Split(' ').Select(w => w.Trim()).ToArray();
            var contacts = _db.Set<Contact>()
                .Where(c => words.All(w => (!(c.Name == null || c.Name.Trim() == string.Empty) && c.Name.Contains(w)) 
                                        || (!(c.Surname == null || c.Surname.Trim() == string.Empty) && c.Surname.Contains(w))))
                .OrderBy(c => c.Surname)
                .ThenBy(c => c.Name)
                .ToList();

            return contacts;
        }
    }
}