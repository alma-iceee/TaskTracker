using Microsoft.AspNetCore.Mvc;
using TaskTracker.Services.Interfaces;

namespace TaskTracker.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : CrudControllerBase<Models.Task>
    {
        public TaskController(ILogger<TaskController> logger, IUnitOfWork unitOfWork) : base(logger, unitOfWork)
        {
        }
    }
}
