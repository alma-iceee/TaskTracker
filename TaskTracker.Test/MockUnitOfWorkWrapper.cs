using Moq;
using TaskTracker.Models;
using TaskTracker.Services.Interfaces;

namespace TaskTracker.Test
{
    public static class MockUnitOfWorkWrapper
    {
        public static Mock<IUnitOfWork> GetMock()
        {
            var mock = new Mock<IUnitOfWork>();

            mock.Setup(m => m.Repository<Project>()).Returns(() => new Mock<IProjectRepository>().Object);
            mock.Setup(m => m.Repository<Models.Task>()).Returns(() => new Mock<ITaskRepository>().Object);
            mock.Setup(m => m.Save()).Callback(() => { return; });

            return mock;
        }
    }
}
