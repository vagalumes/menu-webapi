namespace Application.UseCases.Restaurants.v1.DeleteRestaurantUseCase.Abstractions;

public interface IDeleteRestaurantUseCase
{
    Task ExecuteAsync(Guid restaurantId, CancellationToken cancellationToken);
    void SetOutputPort(IOutputPort outputPort);
}