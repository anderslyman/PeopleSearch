using System.Data.Entity;
using PeopleSearch.DataContexts;
using PeopleSearch.Models;
using PeopleSearch.Services.Interfaces;

namespace PeopleSearch.Services.Implementations
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext() : base("PeopleSearch")
        {
            Database.SetInitializer(new DbInitializer());
        }

        public DbSet<Contact> Contacts { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}