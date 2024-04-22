using Application.Shared.Notifications;
using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Abstractions;
using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Models;
using FluentValidation;

namespace Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase;

public class UpdateMenuItemValidation(
    IValidator<UpdateMenuItemRequest> validator,
    IUpdateMenuItemUseCase useCase,
    Notification notification) : IUpdateMenuItemUseCase
{
    private IOutputPort? _outputPort;

    public void SetOutputPort(IOutputPort outputPort)
    {
        _outputPort = outputPort;
        useCase.SetOutputPort(_outputPort);
    }

    public async Task ExecuteAsync(Guid id, Guid menuItemId, UpdateMenuItemRequest request,
        CancellationToken cancellationToken)
    {
        var result = await validator.ValidateAsync(request, cancellationToken);
        notification.AddErrorMessages(result);

        if (notification.IsInvalid)
        {
            _outputPort!.InvalidRequest();
            return;
        }

        await useCase.ExecuteAsync(id, menuItemId, request, cancellationToken);
    }
}