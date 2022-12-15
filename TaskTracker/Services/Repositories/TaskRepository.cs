using TaskTracker.Data;
using TaskTracker.Services.Interfaces;

namespace TaskTracker.Services.Repositories
{
    public class TaskRepository : Repository<Models.Task>, ITaskRepository
    {
        public TaskRepository(ILogger<TaskRepository> logger, ApplicationDbContext context) : base(logger, context)
        {
        }
    }
}
