using Microsoft.AspNetCore.Http;
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
        public async void GetProjects()
        {
            var _unitOfWork = MockWrapper.GetUnitOfWorkMock().Object;

            var _logger = MockWrapper.GetProjectControllerLoggerMock().Object;

            var controller = new ProjectController(_logger, _unitOfWork);

            // Act
            var result = await controller.Get();

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);

            Assert.Equal(okObjectResult.StatusCode, StatusCodes.Status200OK);
        }

        [Fact]
        public async void GetProject()
        {
            var _unitOfWork = MockWrapper.GetUnitOfWorkMock().Object;

            var _logger = MockWrapper.GetProjectControllerLoggerMock().Object;

            var controller = new ProjectController(_logger, _unitOfWork);

            // Act
            var result = await controller.Get(0);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);

            Assert.Equal(notFoundObjectResult.StatusCode, StatusCodes.Status404NotFound);
        }

        [Fact]
        public async void PostProject()
        {
            var _unitOfWork = MockWrapper.GetUnitOfWorkMock().Object;

            var _logger = MockWrapper.GetProjectControllerLoggerMock().Object;

            var controller = new ProjectController(_logger, _unitOfWork);

            // Act
            var result = await controller.Get(0);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);

            Assert.Equal(notFoundObjectResult.StatusCode, StatusCodes.Status404NotFound);
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
