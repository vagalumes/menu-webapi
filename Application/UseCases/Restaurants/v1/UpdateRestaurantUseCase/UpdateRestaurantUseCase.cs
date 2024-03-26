using Application.Shared.Entities;
using Application.Shared.Services.Abstractions;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Abstractions;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Models;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Services.Repositories.Abstractions;

namespace Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase
{
    public class UpdateRestaurantUseCase(IRestaurantRepository repository, IUnitOfWork unitOfWork) : IUpdateRestaurantUseCase
    {
        private IOutputPort? _outputPort;

        public void SetOutputPort(IOutputPort outputPort) => _outputPort = outputPort;

        public async Task ExecuteAsync(Guid id, UpdateRestaurantRequest request, CancellationToken cancellationToken)
        {
            var restaurant = await repository.GetRestaurant(id, cancellationToken);

            if (restaurant is null)
            {
                _outputPort!.RestaurantNotFound();
                return;
            }

            restaurant.Update(request);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            _outputPort!.RestaurantUpdated();
        }
    }
}
