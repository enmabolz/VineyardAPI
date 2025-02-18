using Moq;
using VineyardAPI.Interfaces.Repositories;
using VineyardAPI.Models;
using VineyardAPI.Services;

namespace VineyardAPITests.ServicesTests
{
    public class ManagerServiceTests
    {
        private readonly Mock<IManagerRepository> _mockRepository;
        private readonly ManagerService _service;

        public ManagerServiceTests()
        {
            _mockRepository = new Mock<IManagerRepository>();
            _service = new ManagerService(_mockRepository.Object);
        }

        public async Task GetManagersAsync_ReturnsAllManagers()
        {
            // Arrange
            var mockManagers = new List<Manager>
            {
                new Manager { Id = 1, Name = "Miguel Torres", TaxNumber = "132254524" },
                new Manager { Id = 2, Name = "Ana Martín", TaxNumber = "143618668" },
                new Manager { Id = 3, Name = "Carlos Ruiz", TaxNumber = "78903228" }
            };

            _mockRepository.Setup(repo => repo.GetAllManagersAsync())
                           .ReturnsAsync(mockManagers);

            // Act
            var result = await _service.GetIdsOfManagersAsync();

            // Assert
            var expectedResult = new List<int> 
            {
                1, 
                2, 
                3,
            };

            Assert.Equal(3, result.Count());
            Assert.Equal(expectedResult, result);
        }
    }
}
