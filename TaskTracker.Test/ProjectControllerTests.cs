using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Controllers.API;

namespace TaskTracker.Test
{
    public class ProjectControllerTests
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

            Assert.Equal(StatusCodes.Status200OK, okObjectResult.StatusCode);
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

            Assert.Equal(StatusCodes.Status404NotFound, notFoundObjectResult.StatusCode);
        }

        [Fact]
        public async void PostProject()
        {
            var _unitOfWork = MockWrapper.GetUnitOfWorkMock().Object;

            var _logger = MockWrapper.GetProjectControllerLoggerMock().Object;

            var controller = new ProjectController(_logger, _unitOfWork);

            // Act
            var project = MockWrapper.GetProjectMock().Object;
            var result = await controller.Post(project);

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result);

            Assert.Equal(StatusCodes.Status201Created, createdResult.StatusCode);
            Assert.Equal(createdResult.Value, project);
        }

        [Fact]
        public async void PutProject()
        {
            var _unitOfWork = MockWrapper.GetUnitOfWorkMock().Object;

            var _logger = MockWrapper.GetProjectControllerLoggerMock().Object;

            var controller = new ProjectController(_logger, _unitOfWork);

            // Act
            var project = MockWrapper.GetProjectMock().Object;

            var result = await controller.Put(project);

            // Assert
            var noContentResult = Assert.IsType<NoContentResult>(result);

            Assert.Equal(StatusCodes.Status204NoContent, noContentResult.StatusCode);
        }

        [Fact]
        public async void PatchProject()
        {
            var _unitOfWork = MockWrapper.GetUnitOfWorkMock().Object;

            var _logger = MockWrapper.GetProjectControllerLoggerMock().Object;

            var controller = new ProjectController(_logger, _unitOfWork);

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

            var _logger = MockWrapper.GetProjectControllerLoggerMock().Object;

            var controller = new ProjectController(_logger, _unitOfWork);

            // Act IContractResolver
            var result = await controller.Delete(0);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);

            Assert.Equal(StatusCodes.Status404NotFound, notFoundObjectResult.StatusCode);
        }
    }
}
