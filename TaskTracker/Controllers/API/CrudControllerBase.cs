using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Services.Interfaces;

namespace TaskTracker.Controllers.API
{
    /// <summary>
    ///     A base interface for a CRUD API controller.
    /// </summary>
    public interface ICrudControllerBase<TEntity> where TEntity : class
    {
        public Task<IActionResult> Get([FromRoute] int id);

        public Task<IActionResult> Get();

        public Task<IActionResult> Post([FromBody] TEntity entity);

        public Task<IActionResult> Put([FromBody] TEntity entity);

        public Task<IActionResult> Patch([FromRoute] int id, [FromBody] JsonPatchDocument jsonPatchDocument);

        public Task<IActionResult> Delete([FromRoute] int id);
    }

    /// <summary>
    ///     A base class for a CRUD API controller.
    /// </summary>
    /// <remarks>
    ///     An example to create a new CRUD API controller for specific entity extended by this class
    ///     <see cref="ProjectController"./>
    /// </remarks>
    public class CrudControllerBase<TEntity> : ControllerBase, ICrudControllerBase<TEntity> where TEntity : class
    {
        private readonly ILogger<CrudControllerBase<TEntity>> _logger;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CrudControllerBase<typeparamref name="TEntity"/>"/> class.
        /// </summary>
        /// <param name="logger">An injected logger <see cref="ILogger"/></param>
        /// <param name="unitOfWork">An injected UnitOfWork <see cref="IUnitOfWork"/></param>
        public CrudControllerBase(ILogger<CrudControllerBase<TEntity>> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        ///     An HttpGet request method <see cref="HttpGetAttribute"/> to find the entity by id.
        /// </summary>
        /// <param name="id">An id of the entity</param>
        /// <returns>
        ///     If method founds the entity gets an <see cref="StatusCodes.Status200OK"/> with the entity for the
        ///     response. In another case, gets an <see cref="StatusCodes.Status404NotFound"/>
        /// </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var entity = await _unitOfWork.Repository<TEntity>().Get(id);

            if (entity == null)
            {
                return NotFound($"Not found {nameof(entity)} with id = {id}");
            }

            return Ok(entity);
        }

        /// <summary>
        ///     An HttpGet request method <see cref="HttpGetAttribute"/> to get all entities.
        /// </summary>
        /// <returns>Gets an <see cref="StatusCodes.Status200OK"/> with entities for the response</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var entities = await _unitOfWork.Repository<TEntity>().GetAll();

            return Ok(entities);
        }

        /// <summary>
        ///     An HttpPost request method <see cref="HttpGetAttribute"/> to create the entity.
        /// </summary>
        /// <param name="entity">An entity</param>
        /// <returns>Gets an <see cref="StatusCodes.Status201Created"/> with an uri and an entity for the response</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TEntity entity)
        {
            _unitOfWork.Repository<TEntity>().Add(entity);
            await _unitOfWork.Save();

            return Created($"/api/{nameof(entity)}", entity);
        }

        /// <summary>
        ///     An HttpPut request method <see cref="HttpGetAttribute"/> to update entity.
        /// </summary>
        /// <param name="entity">An entity</param>
        /// <returns>Gets an <see cref="StatusCodes.NoContent"/></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TEntity entity)
        {
            _unitOfWork.Repository<TEntity>().Update(entity);
            await _unitOfWork.Save();

            return NoContent();
        }

        /// <summary>
        ///     An HttpPatch request method <see cref="HttpGetAttribute"/> to update the entity by id.
        /// </summary>
        /// <param name="id">An id</param>
        /// <param name="entityDocument">An json patch document <see cref="JsonPatchDocument"/></param>
        /// <returns>
        ///     If method founds the entity gets an <see cref="StatusCodes.NoContent"/>. In another case, gets an
        ///     <see cref="StatusCodes.Status404NotFound"/>
        /// </returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument entityDocument)
        {
            var entity = await _unitOfWork.Repository<TEntity>().Get(id);

            if (entity == null)
            {
                return NotFound($"Not found {nameof(entity)} with id = {id}");
            }

            entityDocument.ApplyTo(entity);
            await _unitOfWork.Save();

            return NoContent();
        }

        /// <summary>
        ///     An HttpDelete request method <see cref="HttpGetAttribute"/> to delete the entity by id.
        /// </summary>
        /// <param name="id">An id</param>
        /// <returns>
        ///     If method founds the entity gets an <see cref="StatusCodes.NoContent"/>. In another case, gets an
        ///     <see cref="StatusCodes.Status404NotFound"/>
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _unitOfWork.Repository<TEntity>().Get(id);

            if (entity == null)
            {
                return NotFound($"Not found {nameof(entity)} with id = {id}");
            }

            _unitOfWork.Repository<TEntity>().Delete(entity);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
