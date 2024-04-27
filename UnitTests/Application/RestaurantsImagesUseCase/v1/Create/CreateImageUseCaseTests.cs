using Application.Shared.Entities;
using Application.Shared.Services.Abstractions;
using Application.UseCases.RestaurantsImagesUseCase.v1.CreateRestaurantImageUseCase;
using Application.UseCases.RestaurantsImagesUseCase.v1.CreateRestaurantImageUseCase.Abstractions;
using Application.UseCases.RestaurantsImagesUseCase.v1.CreateRestaurantImageUseCase.Services.Repositories.Abstractions;
using AutoFixture;
using Microsoft.AspNetCore.Http;
using Moq;

namespace UnitTests.Application.RestaurantsImagesUseCase.v1.Create;

public class CreateImageUseCaseTests
{
    private readonly Mock<IImageRepository> _mockImageRepository = new();
    private readonly Mock<IImagesService> _mockImagesService = new();
    private readonly Mock<IUnitOfWork> _mockUnitOfWork = new();
    private readonly Mock<IOutputPort> _mockOutputPort = new();
    private readonly Fixture _fixture = new();
    private readonly CreateRestaurantCreateRestaurantImageUseCase _service;

    public CreateImageUseCaseTests()
    {
        _service = new CreateRestaurantCreateRestaurantImageUseCase(_mockImageRepository.Object, _mockImagesService.Object,
            _mockUnitOfWork.Object);
        _service.SetOutputPort(_mockOutputPort.Object);
    }

    [Fact]
    public async Task ExecuteAsync_WhenRestaurantNotFound_MustCallRestaurantNotFound()
    {
        // Arrange
        _mockImageRepository.Setup(x => x.GetRestaurant(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Restaurant?)null);

        // Act
        await _service.ExecuteAsync(Guid.NewGuid(), CreateMockFormFile(), CancellationToken.None);

        // Assert
        _mockOutputPort.Verify(x => x.RestaurantNotFound(), Times.Once);
    }

    [Fact]
    public async Task ExecuteAsync_WhenRestaurantFound_MustCallImagesSaved()
    {
        var file = CreateMockFormFile();
        // Arrange
        _mockImageRepository.Setup(x => x.GetRestaurant(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Restaurant());
        _mockImagesService.Setup(x =>
                x.UploadFile(It.IsAny<string>(), It.IsAny<IFormFile>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new FileInfo(file.FileName));

        // Act
        await _service.ExecuteAsync(Guid.NewGuid(), CreateMockFormFile(), CancellationToken.None);

        // Assert
        _mockOutputPort.Verify(x => x.ImagesSaved(), Times.Once);
        _mockUnitOfWork.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        _mockOutputPort.Verify(o => o.RestaurantNotFound(), Times.Never);
    }
    
    private static IFormFile CreateMockFormFile()
    {
        var fileMock = new Mock<IFormFile>();
        const string content = "Hello World from a Fake File";
        const string fileName = "test.txt";
        var ms = new MemoryStream();
        var writer = new StreamWriter(ms);
        writer.Write(content);
        writer.Flush();
        ms.Position = 0;
        fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
        fileMock.Setup(_ => _.FileName).Returns(fileName);
        fileMock.Setup(_ => _.Length).Returns(ms.Length);
        return fileMock.Object;
    }
}