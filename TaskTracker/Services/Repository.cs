using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskTracker.Data;
using TaskTracker.Services.Interfaces;
using TaskTracker.Services.Repositories;

namespace TaskTracker.Services
{
    /// <summary>
    ///     A base class for a repository.
    /// </summary>
    /// <remarks>
    ///     An example to create a new repository for specific entity extended by this class
    ///     <see cref="ProjectRepository"/>
    /// </remarks>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ILogger<Repository<TEntity>> _logger;
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Repository<typeparamref name="TEntity"/>"/> class.
        /// </summary>
        /// <param name="logger">An injected logger <see cref="ILogger"/></param>
        /// <param name="context">An injected database context <see cref="ApplicationDbContext"/></param>
        public Repository(ILogger<Repository<TEntity>> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        /// <summary>
        ///     The async method to get the entity by id.
        /// </summary>
        /// <param name="id">An id of entity</param>
        /// <returns>Entity <see cref="Task<typeparamref name="TEntity"/>"/></returns>
        public async Task<TEntity?> Get(int id)
            => await _dbSet.FindAsync(id);

        /// <summary>
        ///     The async method to get the entity by Linq Expression.
        /// </summary>
        /// <param name="predicate">Linq Expression <see cref="Expression"/></param>
        /// <returns>Entity <see cref="Task<typeparamref name="TEntity"/>"/></returns>
        public async Task<TEntity?> Find(Expression<Func<TEntity, bool>> predicate)
            => await _dbSet.FirstOrDefaultAsync(predicate);

        /// <summary>
        ///     The async method to get all entities.
        /// </summary>
        /// <returns>Entity <see cref="Task<typeparamref name="TEntity"/>"/></returns>
        public async Task<IEnumerable<TEntity>> GetAll()
            => await _dbSet.ToListAsync();

        /// <summary>
        ///     The async method to get entities by Linq Expression.
        /// </summary>
        /// <param name="predicate">Linq Expression <see cref="Expression"/></param>
        /// <returns>Entity <see cref="Task<typeparamref name="TEntity"/>"/></returns>
        public async Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate)
            => await _dbSet.Where(predicate).ToListAsync();

        /// <summary>
        ///     The async method to add an entity.
        /// </summary>
        /// <param name="entity">An entity</param>
        public async void Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        /// <summary>
        ///     The async method to add entities.
        /// </summary>
        /// <param name="entities">Entites</param>
        public async void AddRange(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        /// <summary>
        ///     The async method to update the entity.
        /// </summary>
        /// <param name="entity">An entity</param>
        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        /// <summary>
        ///     The async method to update entities.
        /// </summary>
        /// <param name="entities">Entites</param>
        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        /// <summary>
        ///     The async method to delete the entity.
        /// </summary>
        /// <param name="entity">An entity</param>
        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        /// <summary>
        ///     The async method to delete entities.
        /// </summary>
        /// <param name="entities">Entites</param>
        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
