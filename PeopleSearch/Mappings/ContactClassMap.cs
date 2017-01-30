using CsvHelper.Configuration;
using PeopleSearch.Models;

namespace PeopleSearch.Mappings
{
    public sealed class ContactClassMap : CsvClassMap<Contact>
    {
        public ContactClassMap()
        {
            Map(c => c.Name).Name("Name");
            Map(c => c.Surname).Name("Surname");
            Map(c => c.Birthdate).Name("Birthdate");
            Map(c => c.StreetAddress).Name("Street Address");
            Map(c => c.City).Name("City");
            Map(c => c.State).Name("State");
            Map(c => c.Zip).Name("Zip");
            Map(c => c.Phone).Name("Phone");
            Map(c => c.Interests).Name("Interests");
            Map(c => c.Photo).Name("Photo");
        }
    }
}