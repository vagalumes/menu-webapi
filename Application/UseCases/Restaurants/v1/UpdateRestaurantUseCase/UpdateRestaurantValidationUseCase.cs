using Application.Shared.Notifications;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Abstractions;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Models;
using FluentValidation;

namespace Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase;

public class UpdateRestaurantValidationUseCase(
    IValidator<UpdateRestaurantRequest> validator,
    IUpdateRestaurantUseCase useCase,
    Notification notification) : IUpdateRestaurantUseCase
{
    private IOutputPort? _outputPort;

    public void SetOutputPort(IOutputPort outputPort)
    {
        _outputPort = outputPort;
        useCase.SetOutputPort(_outputPort);
    }

    public async Task ExecuteAsync(Guid id, UpdateRestaurantRequest request, CancellationToken cancellationToken)
    {
        var result = await validator.ValidateAsync(request, cancellationToken);

        notification.AddErrorMessages(result);

        if (notification.IsInvalid)
        {
            _outputPort!.InvalidRequest();
            return;
        }

        await useCase.ExecuteAsync(id, request, cancellationToken);
    }
}