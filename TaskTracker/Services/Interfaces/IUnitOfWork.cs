
namespace TaskTracker.Services.Interfaces
{
    /// <summary>
    ///     An interface for UnitOfWork.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task<bool> Save();
    }
}
