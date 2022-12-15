using TaskTracker.Data;
using TaskTracker.Models;
using TaskTracker.Services.Interfaces;

namespace TaskTracker.Services.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(ILogger<ProjectRepository> logger, ApplicationDbContext context) : base(logger, context)
        {
        }
    }
}
