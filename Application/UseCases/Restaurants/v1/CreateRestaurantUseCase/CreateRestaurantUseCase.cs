using Application.Shared.Entities;
using Application.Shared.Services.Abstractions;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Abstractions;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Models;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Services.Repositories.Abstractions;

namespace Application.UseCases.Restaurants.v1.CreateRestaurantUseCase
{
    public class CreateRestaurantUseCase(IRestaurantRepository repository, IUnitOfWork unitOfWork) : ICreateRestaurantUseCase
    {
        private IOutputPort? _outputPort;

        public void SetOutputPort(IOutputPort outputPort) => _outputPort = outputPort;

        public async Task ExecuteAsync(CreateRestaurantRequest request, CancellationToken cancellationToken)
        {
            var restaurantExists = await repository.RestaurantExists(request.Cnpj);

            if(restaurantExists)
            {
                _outputPort!.RestaurantAlreadyExists();
                return;
            }

            await SaveRestaurant(request, cancellationToken);

            _outputPort!.RestaurantCreated();
        }

        private async Task SaveRestaurant(CreateRestaurantRequest request, CancellationToken cancellationToken)
        {
            var restaurant = new Restaurant(request);

            await repository.CreateRestaurant(restaurant, cancellationToken);

            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
