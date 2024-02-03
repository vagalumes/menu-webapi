using Application.Shared.Notifications;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Abstractions;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Models;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Services.Repositories.Abstractions;

namespace Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase
{
    public class UpdateRestaurantValidationUseCase(IUpdateRestaurantUseCase useCase, IRestaurantRepository repository, Notification notification) : IUpdateRestaurantUseCase
    {
        private IOutputPort? _outputPort;

        public async Task ExecuteAsync(Guid id, UpdateRestaurantRequest request, CancellationToken cancellationToken)
        {
            var restaurant = await repository.GetRestaurant(id, cancellationToken);

            if (restaurant is null)
                notification.AddErrorMessage(nameof(id), "Restaurante não localizado");

            if (notification.IsInvalid)
            {
                _outputPort!.RestaurantNotFound();
                return;
            }

            await useCase.ExecuteAsync(id, request, cancellationToken);
        }

        public void SetOutputPort(IOutputPort outputPort)
        {
            _outputPort = outputPort;
            useCase.SetOutputPort(_outputPort);
        }
    }
}
