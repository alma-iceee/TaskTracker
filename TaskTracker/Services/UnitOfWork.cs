using TaskTracker.Data;
using TaskTracker.Models;
using TaskTracker.Services.Interfaces;

namespace TaskTracker.Services
{
    /// <summary>
    ///     A base class for a UnitOfWork.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ILogger<UnitOfWork> _logger;
        private readonly ApplicationDbContext _dbContext;
        private IProjectRepository _projectRepository;
        private ITaskRepository _taskRepository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="logger">An injected logger <see cref="ILogger"/></param>
        /// <param name="dbContext">An injected database context <see cref="ApplicationDbContext"/></param>
        /// <param name="projectRepository">An injected project repository <see cref="IProjectRepository"/></param>
        /// <param name="taskRepository">An injected task repository <see cref="ITaskRepository"/></param>
        public UnitOfWork(
            ILogger<UnitOfWork> logger,
            ApplicationDbContext dbContext,
            IProjectRepository projectRepository,
            ITaskRepository taskRepository)
        {
            _logger = logger;
            _projectRepository= projectRepository;
            _taskRepository = taskRepository;
            _dbContext = dbContext;
        }

        /// <summary>
        ///     Gets an project repository.
        /// </summary>
        public IRepository<Project> ProjectRepository => _projectRepository;

        /// <summary>
        ///     Gets an task repository.
        /// </summary>
        public IRepository<Models.Task> TaskRepository => _taskRepository;

        /// <summary>
        ///     Gets an specific repository.
        /// </summary>
        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var methods = GetType().GetMethods();

            foreach (var method in methods)
            {
                if (method.ReturnType == typeof(IRepository<TEntity>))
                {
                    return (IRepository<TEntity>)GetType().GetMethod(method.Name).Invoke(this, null);
                }
            }

            throw new Exception("Repository not found");
        }

        /// <summary>
        ///     Saves changes in database.
        /// </summary>
        public async Task<bool> Save() => await _dbContext.SaveChangesAsync() > 0;

        /// <summary>
        ///     Finilaze instance.
        /// </summary>
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
