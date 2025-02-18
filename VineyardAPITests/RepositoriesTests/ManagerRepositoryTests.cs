using Moq;
using VineyardAPI.Models.Entities;
using VineyardAPI.Repositories.Interfaces;

namespace VineyardAPITests.RepositoriesTests;

public class ManagerRepositoryTests
{
    private readonly Mock<IManagerRepository> _mockRepository;

    public ManagerRepositoryTests()
    {
        _mockRepository = new Mock<IManagerRepository>();
    }

    [Fact]
    public async Task GetManagersAsync_ReturnsAllManagers()
    {
        // Arrange
        var mockManagers = new List<Manager>
        {
            new Manager { Id = 1, Name = "Miguel Torres", TaxNumber = "132254524" },
            new Manager { Id = 2, Name = "Ana Martín", TaxNumber = "143618668" }
        };

        _mockRepository.Setup(repo => repo.GetAllManagersWithoutParcelsAsync())
                       .ReturnsAsync(mockManagers);

        // Act
        var result = await _mockRepository.Object.GetAllManagersWithoutParcelsAsync();

        // Assert
        var expectedResult = new List<Manager> 
        {
            new Manager { Id = 1, Name = "Miguel Torres", TaxNumber = "132254524" },
            new Manager { Id = 2, Name = "Ana Martín", TaxNumber = "143618668" }
        };

        var expectedTaxNumbers = expectedResult.Select(x => x.TaxNumber); 
        var taxNumbersResult = result.Select(x => x.TaxNumber);

        var expectedIds = expectedResult.Select(x => x.Id);
        var idsResult = result.Select(x => x.Id);

        var namesResult = result.Select(x => x.Name);
        var expectedNames = expectedResult.Select(x => x.Name);

        Assert.Equal(expectedIds, idsResult);
        Assert.Equal(expectedTaxNumbers, taxNumbersResult);
        Assert.Equal(expectedNames, namesResult);

        Assert.Equal(2, result.Count());
        
    }
}
