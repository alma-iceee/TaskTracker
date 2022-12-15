using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Controllers.API;

namespace TaskTracker.Test
{
    public class TaskControllerTests
    {
        [Fact]
        public async void GetTasks()
        {
            var _unitOfWork = MockWrapper.GetUnitOfWorkMock().Object;

            var _logger = MockWrapper.GetTaskControllerLoggerMock().Object;

            var controller = new TaskController(_logger, _unitOfWork);

            // Act
            var result = await controller.Get();

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);

            Assert.Equal(StatusCodes.Status200OK, okObjectResult.StatusCode);
        }

        [Fact]
        public async void GetProject()
        {
            var _unitOfWork = MockWrapper.GetUnitOfWorkMock().Object;

            var _logger = MockWrapper.GetTaskControllerLoggerMock().Object;

            var controller = new TaskController(_logger, _unitOfWork);

            // Act
            var result = await controller.Get(0);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);

            Assert.Equal(StatusCodes.Status404NotFound, notFoundObjectResult.StatusCode);
        }

        [Fact]
        public async void PostProject()
        {
            var _unitOfWork = MockWrapper.GetUnitOfWorkMock().Object;

            var _logger = MockWrapper.GetTaskControllerLoggerMock().Object;

            var controller = new TaskController(_logger, _unitOfWork);

            // Act
            var task = MockWrapper.GetTaskMock().Object;
            var result = await controller.Post(task);

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result);

            Assert.Equal(StatusCodes.Status201Created, createdResult.StatusCode);
            Assert.Equal(createdResult.Value, task);
        }

        [Fact]
        public async void PutProject()
        {
            var _unitOfWork = MockWrapper.GetUnitOfWorkMock().Object;

            var _logger = MockWrapper.GetTaskControllerLoggerMock().Object;

            var controller = new TaskController(_logger, _unitOfWork);

            // Act
            var task = MockWrapper.GetTaskMock().Object;

            var result = await controller.Put(task);

            // Assert
            var noContentResult = Assert.IsType<NoContentResult>(result);

            Assert.Equal(StatusCodes.Status204NoContent, noContentResult.StatusCode);
        }

        [Fact]
        public async void PatchProject()
        {
            var _unitOfWork = MockWrapper.GetUnitOfWorkMock().Object;

            var _logger = MockWrapper.GetTaskControllerLoggerMock().Object;

            var controller = new TaskController(_logger, _unitOfWork);

            // Act IContractResolver
            var jsonPatchDocument = MockWrapper.GetJsonPatchDocumentMock().Object;

            var result = await controller.Patch(0, jsonPatchDocument);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);

            Assert.Equal(StatusCodes.Status404NotFound, notFoundObjectResult.StatusCode);
        }

        [Fact]
        public async void DeleteProject()
        {
            var _unitOfWork = MockWrapper.GetUnitOfWorkMock().Object;

            var _logger = MockWrapper.GetTaskControllerLoggerMock().Object;

            var controller = new TaskController(_logger, _unitOfWork);

            // Act IContractResolver
            var result = await controller.Delete(0);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);

            Assert.Equal(StatusCodes.Status404NotFound, notFoundObjectResult.StatusCode);
        }
    }
}
