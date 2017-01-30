using System;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleSearch.Services.Interfaces
{
    public interface IDataContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbSet Set(Type entityType);
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}