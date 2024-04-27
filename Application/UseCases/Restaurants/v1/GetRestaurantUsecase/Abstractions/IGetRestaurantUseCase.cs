namespace Application.UseCases.Restaurants.v1.GetRestaurantUsecase.Abstractions;

public interface IGetRestaurantUseCase
{
    void SetOutputPort(IOutputPort outputPort);
    Task ExecuteAsync(Guid restaurantId, CancellationToken cancellationToken);
}