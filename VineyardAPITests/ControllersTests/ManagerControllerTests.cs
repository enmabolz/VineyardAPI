using Microsoft.AspNetCore.Mvc;
using Moq;
using VineyardAPI.Controllers;
using VineyardAPI.Services.Interfaces;


namespace VineyardAPITests.ControllersTests;

public class ManagersControllerTests
{
    [Fact]
    public async Task GetAllIdsOfManagersAsync_ReturnsOkResult_WithManagerIds()
    {
        // Arrange
        var mockManagerService = new Mock<IManagerService>();
        mockManagerService.Setup(service => service.GetIdsOfManagersAsync())
                          .ReturnsAsync(new List<int> { 1, 2, 3 });

        var controller = new ManagersController(mockManagerService.Object);

        // Act
        var result = await controller.GetAllIdsOfManagersAsync();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsAssignableFrom<IEnumerable<int>>(okResult.Value);
        
        Assert.Equal(new List<int> { 1, 2, 3 }, returnValue);
    }

    [Fact]
    public async Task GetAllIdsOfManagersAsync_ReturnsInternalServerError_OnException()
    {
        // Arrange
        var mockManagerService = new Mock<IManagerService>();

        mockManagerService.Setup(service => service.GetIdsOfManagersAsync())
                          .ThrowsAsync(new Exception("Test exception"));

        var controller = new ManagersController(mockManagerService.Object);

        // Act
        var result = await controller.GetAllIdsOfManagersAsync();

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result); 
        Assert.Equal(500, objectResult.StatusCode); 
    }


    [Fact]
    public async Task GetManagersTotalAdministratedAreaAsync_ReturnsOkResult_WithAreaData()
    {
        // Arrange
        var mockManagerService = new Mock<IManagerService>();
        mockManagerService.Setup(service => service.GetManagersTotalAdministratedAreaAsync())
                          .ReturnsAsync(new Dictionary<string, int>
                          {
                              { "Miguel Torres", 1500 },
                              { "Ana Martín", 9000 },
                              { "Carlos Ruiz", 3000 }
                          });

        var controller = new ManagersController(mockManagerService.Object);

        // Act
        var result = await controller.GetManagersTotalAdministratedAreaAsync();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsAssignableFrom<Dictionary<string, int>>(okResult.Value);
        Assert.Equal(new Dictionary<string, int>
        {
            { "Miguel Torres", 1500 },
            { "Ana Martín", 9000 },
            { "Carlos Ruiz", 3000 }
        }, returnValue);
    }

    [Fact]
    public async Task GetManagersTotalAdministratedAreaAsync_ReturnsInternalServerError_OnException()
    {
        // Arrange
        var mockManagerService = new Mock<IManagerService>();
        mockManagerService.Setup(service => service.GetManagersTotalAdministratedAreaAsync())
                          .ThrowsAsync(new Exception("Test exception"));

        var controller = new ManagersController(mockManagerService.Object);

        // Act
        var result = await controller.GetManagersTotalAdministratedAreaAsync();

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result);

        Assert.Equal(500, objectResult.StatusCode);  
    }
}
