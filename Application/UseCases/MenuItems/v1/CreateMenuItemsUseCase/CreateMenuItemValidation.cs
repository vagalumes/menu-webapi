using Application.Shared.Notifications;
using Application.UseCases.MenuItemsImageUseCase.v1.CreateMenuItemsUseCase.Abstractions;
using Application.UseCases.MenuItemsImageUseCase.v1.CreateMenuItemsUseCase.Models;

namespace Application.UseCases.MenuItemsImageUseCase.v1.CreateMenuItemsUseCase
{
    public class CreateMenuItemValidation(ICreateMenuItemsUseCase useCase, Notification notification) : ICreateMenuItemsUseCase
    {
        private IOutputPort? _outputPort;

        public void SetOutputPort(IOutputPort outputPort)
        {
            _outputPort = outputPort;
            useCase.SetOutputPort(outputPort);
        }

        public async Task ExecuteAsync(Guid id, CreateMenuItemsRequest request, CancellationToken cancellationToken)
        {
            if (request.Price == 0)
                notification.AddErrorMessage(nameof(request.Price), "Necessário informar o valor a ser cobrado");

            if (notification.IsInvalid)
            {
                _outputPort!.InvalidRequest();
                return;
            }

            await useCase.ExecuteAsync(id, request, cancellationToken);
        }
    }
}
