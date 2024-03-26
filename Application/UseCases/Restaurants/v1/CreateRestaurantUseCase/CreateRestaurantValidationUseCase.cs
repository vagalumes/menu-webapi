using Application.Shared.Notifications;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Abstractions;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Models;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Services.Repositories.Abstractions;
using FluentValidation;

namespace Application.UseCases.Restaurants.v1.CreateRestaurantUseCase
{
    public class CreateRestaurantValidationUseCase(IRestaurantRepository repository, ICreateRestaurantUseCase useCase, IValidator<CreateRestaurantRequest> validator, Notification notification) : ICreateRestaurantUseCase
    {
        private IOutputPort? _outputPort;

        public void SetOutputPort(IOutputPort outputPort)
        {
            _outputPort = outputPort;
            useCase.SetOutputPort(outputPort);
        }

        public async Task ExecuteAsync(CreateRestaurantRequest request, CancellationToken cancellationToken)
        {
            var result = await validator.ValidateAsync(request, cancellationToken);
            
            notification.AddErrorMessages(result);
            
            if (notification.IsInvalid)
            {
                _outputPort!.InvalidRequest();
                return;
            }

            await useCase.ExecuteAsync(request, cancellationToken);
        }
    }
}
