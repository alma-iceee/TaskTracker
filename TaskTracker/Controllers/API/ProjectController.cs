using Microsoft.AspNetCore.Mvc;
using TaskTracker.Models;
using TaskTracker.Services.Interfaces;

namespace TaskTracker.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : CrudControllerBase<Project>
    {
        public ProjectController(ILogger<ProjectController> logger, IUnitOfWork unitOfWork) : base(logger, unitOfWork)
        {
        }
    }
}
