using Application.Shared.Notifications;
using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Abstractions;
using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Models;
using FluentValidation;

namespace Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase
{
    public class CreateMenuItemValidation(
        ICreateMenuItemsUseCase useCase,
        IValidator<CreateMenuItemsRequest> validator,
        Notification notification)
        : ICreateMenuItemsUseCase
    {
        private IOutputPort? _outputPort;

        public void SetOutputPort(IOutputPort outputPort)
        {
            _outputPort = outputPort;
            useCase.SetOutputPort(outputPort);
        }

        public async Task ExecuteAsync(Guid id, CreateMenuItemsRequest request, CancellationToken cancellationToken)
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
}