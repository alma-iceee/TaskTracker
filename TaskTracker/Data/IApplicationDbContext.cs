using Microsoft.EntityFrameworkCore;

namespace TaskTracker.Data
{
    /// <summary>
    ///     Unused interface for database context.
    /// </summary>
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();
    }
}
