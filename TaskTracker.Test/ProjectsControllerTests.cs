using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Controllers.API;
using TaskTracker.Models;
using TaskTracker.Services.Interfaces;

namespace TaskTracker.Test
{
    public class ProjectsControllerTests
    {
        [Fact]
        public async void IndexReturnsAViewResultWithAListOfUsers()
        {
            var mockUnitOfWork = MockUnitOfWorkWrapper.GetMock();
            var _unitOfWork = mockUnitOfWork.Object;

            var mockLogger = new Mock<ILogger<ProjectController>>();
            ILogger<ProjectController> _logger = mockLogger.Object;

            var controller = new ProjectController(_logger, _unitOfWork);

            // Act
            var result = await controller.Get();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Project>>(result);
            //Assert.Equal(GetTestProjects().Count, model.Count());
        }

        private List<Project> GetTestProjects()
        {
            var projects = new List<Project>
            {
                new Project
                {
                    Id = 1,
                    Name = "Project1",
                    StartDate = DateTime.Now,
                    Status = Models.Enums.ProjectStatus.NotStarted,
                    Priority = 1
                },
                new Project
                {
                    Id = 2,
                    Name = "Project2",
                    StartDate = DateTime.Now,
                    Status = Models.Enums.ProjectStatus.NotStarted,
                    Priority = 2
                },
                new Project
                {
                    Id = 3,
                    Name = "Project3",
                    StartDate = DateTime.Now,
                    Status = Models.Enums.ProjectStatus.NotStarted,
                    Priority = 3
                }
            };

            return projects;
        }
    }
}
