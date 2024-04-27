using Application.Shared.Services.Abstractions;
using Application.UseCases.Restaurants.v1.DeleteRestaurantUseCase.Abstractions;
using Application.UseCases.Restaurants.v1.DeleteRestaurantUseCase.Services.Repositories.Abstractions;

namespace Application.UseCases.Restaurants.v1.DeleteRestaurantUseCase;

public class DeleteRestaurantUseCase(IRestaurantRepository repository, IUnitOfWork unitOfWork)
    : IDeleteRestaurantUseCase
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

        repository.DeletedRestaurant(restaurant);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        _outputPort!.RestaurantDeleted();
    }
}