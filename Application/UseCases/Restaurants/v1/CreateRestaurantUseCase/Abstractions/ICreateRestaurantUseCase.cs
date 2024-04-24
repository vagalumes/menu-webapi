using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Models;

namespace Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Abstractions;

public interface ICreateRestaurantUseCase
{
    void SetOutputPort(IOutputPort outputPort);
    Task ExecuteAsync(CreateRestaurantRequest request, CancellationToken cancellationToken);
}