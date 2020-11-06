using Timelogger.Api.Controllers;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Timelogger.Models;
using System.Linq;
using Moq;
using Timelogger.Repositories.Interfaces;
using Microsoft.Graph;
using NUnit.Framework.Constraints;

namespace Timelogger.Api.Tests
{
    public class ProjectsControllerTests
    {
        private Mock<IProjectRepository> _mockRepo;

        [SetUp]
        public void SetUp()
        {
            _mockRepo = new Mock<IProjectRepository>();
        }

        [Test]
        public void GetAll_ShouldReturn_OkStatusCode()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetAll());
            var controller = new ProjectsController(_mockRepo.Object);

            // Act
            IActionResult result = controller.GetAll() as OkObjectResult;

            // Assert
            int? statusCode = ((OkObjectResult)result).StatusCode;
            Assert.AreEqual(200, statusCode);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void GetById_ShouldReturn_200StatusCode(int value)
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetById(value));
            var controller = new ProjectsController(_mockRepo.Object);
            var result = controller.GetById(value);

            // Assert
            var okRequest = result as OkObjectResult;
            Assert.IsNotNull(okRequest);

            int? okStatus = (okRequest).StatusCode;
            Assert.IsNotNull(okStatus, "Status code was not 200.");

            Assert.AreEqual(200, okStatus, message: "Expected 200, was Ok Object Result");
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void GetById_ShouldReturn_404StatusCode(int value)
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetById(value));
            var controller = new ProjectsController(_mockRepo.Object);
            var result = controller.GetById(value);

            // Assert
            var notFound = result as NotFoundResult;
            Assert.IsNotNull(notFound);

            int? notFoundStatus = (notFound).StatusCode;
            Assert.IsNotNull(notFoundStatus, "Status code was not 404.");

            Assert.AreEqual(404, notFoundStatus, message: "Expected 404, was Not Found Result");
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void GetById_ShouldReturn_400StatusCode(int value)
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetById(value));
            var controller = new ProjectsController(_mockRepo.Object);
            var result = controller.GetById(value);

            // Assert
            var badRequest = result as BadRequestResult;
            Assert.IsNotNull(badRequest);

            int? badStatus = (badRequest).StatusCode;
            Assert.IsNotNull(badStatus, "Status code was not 400.");
            
            Assert.AreEqual(400, badStatus, message: "Expected 400, was Bad Request Result");
        }
    }
}
