using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using CsvHelper;
using PeopleSearch.Mappings;
using PeopleSearch.Models;
using PeopleSearch.Services.Implementations;

namespace PeopleSearch.DataContexts
{
    public class DbInitializer : CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var data = GetResourceAsString(@"SeedData.people.csv");
            var csv = new CsvReader(new StringReader(data));
            
            var map = new ContactClassMap();
            csv.Configuration.RegisterClassMap(map);

            var contacts = csv.GetRecords<Contact>().ToArray();
            
            context.Contacts.AddRange(contacts);
            context.SaveChanges();

            base.Seed(context);
        }

        private string GetResourceAsString(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var result = string.Empty;

            using (var stream = assembly.GetManifestResourceStream($"PeopleSearch.{resourceName}"))
            {
                if (stream != null)
                {
                    using (var reader = new StreamReader(stream))
                    {
                        result = reader.ReadToEnd();
                    }
                }
            }

            return result;
        }
    }
}