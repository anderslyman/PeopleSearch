using System.Collections.Generic;
using PeopleSearch.Models;

namespace PeopleSearch.Services.Interfaces
{
    public interface IContactService
    {
        List<Contact> SearchContacts(string text);
    }
}