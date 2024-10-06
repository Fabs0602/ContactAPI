using ContatoApi.Controllers;
using ContatoApi.Models;
using ContatoApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace ContatoApi.Tests
{
    public class ContatosControllerTests
    {
        [Fact]
        public async Task Get_ReturnsContato_WhenContatoExists()
        {
            // Arrange
            var mockConnectionStringProvider = new Mock<IConnectionStringProvider>();
            mockConnectionStringProvider.Setup(provider => provider.GetConnectionString("MongoDb")).Returns("mongodb://localhost:27017");
            var mockService = new Mock<ContatoService>(mockConnectionStringProvider.Object);
            var contato = new Contato { Id = "60c72b2f9b1e8b3f4c8e4d3a", Nome = "Teste", Telefone = 123456789, Email = "teste@exemplo.com" };
            mockService.Setup(service => service.GetAsync(It.IsAny<string>())).ReturnsAsync(contato);
            var controller = new ContatosController(mockService.Object);

            // Act
            var result = await controller.Get("60c72b2f9b1e8b3f4c8e4d3a");

            // Assert
            var actionResult = Assert.IsType<ActionResult<Contato>>(result);
            var returnValue = Assert.IsType<Contato>(actionResult.Value);
            Assert.Equal(contato.Id, returnValue.Id);
        }

        [Fact]
        public async Task Get_ReturnsNotFound_WhenContatoDoesNotExist()
        {
            // Arrange
            var mockConnectionStringProvider = new Mock<IConnectionStringProvider>();
            mockConnectionStringProvider.Setup(provider => provider.GetConnectionString("MongoDb")).Returns("mongodb://localhost:27017");
            var mockService = new Mock<ContatoService>(mockConnectionStringProvider.Object);
            mockService.Setup(service => service.GetAsync(It.IsAny<string>())).ReturnsAsync((Contato)null);
            var controller = new ContatosController(mockService.Object);

            // Act
            var result = await controller.Get("60c72b2f9b1e8b3f4c8e4d3a");

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}