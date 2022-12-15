using Microsoft.Extensions.Logging;
using Moq;
using TaskTracker.Controllers.API;
using TaskTracker.Models;
using TaskTracker.Services.Interfaces;

namespace TaskTracker.Test
{
    public static class MockWrapper
    {
        public static Mock<IUnitOfWork> GetUnitOfWorkMock()
        {
            var mock = new Mock<IUnitOfWork>();

            mock.Setup(m => m.Repository<Project>()).Returns(() => new Mock<IProjectRepository>().Object);
            mock.Setup(m => m.Repository<Models.Task>()).Returns(() => new Mock<ITaskRepository>().Object);
            mock.Setup(m => m.Save()).Callback(() => { return; });

            return mock;
        }
        public static Mock<ILogger<ProjectController>> GetProjectControllerLoggerMock()
        {
            var mock = new Mock<ILogger<ProjectController>>();

            return mock;
        }
    }
}
