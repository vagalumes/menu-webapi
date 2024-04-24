using Application.UseCases.Restaurants.v1.GetRestaurantUseCase.Abstractions;
using Application.UseCases.Restaurants.v1.GetRestaurantUseCase.Models;
using Application.UseCases.Restaurants.v1.GetRestaurantUseCase.Services.Repositories.Abstractions;

namespace Application.UseCases.Restaurants.v1.GetRestaurantUseCase;

public class GetRestaurantUseCase(IRestaurantRepository repository) : IGetRestaurantUseCase
{
    private IOutputPort? _outputPort;

    public void SetOutputPort(IOutputPort outputPort)
    {
        _outputPort = outputPort;
    }

    public async Task ExecuteAsync(Guid restaurantId, CancellationToken cancellationToken)
    {
        var restaurant = await repository.GetRestaurant(restaurantId, cancellationToken);

        if (restaurant is null)
        {
            _outputPort!.RestaurantNotFound();
            return;
        }

        var restaurantModel = new GetRestaurantModel(restaurant);

        _outputPort!.RestaurantFound(restaurantModel);
    }
}