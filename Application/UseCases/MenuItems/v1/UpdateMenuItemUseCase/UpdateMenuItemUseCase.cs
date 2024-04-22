using Application.Shared.Services.Abstractions;
using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Abstractions;
using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Models;
using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Services.Repositories.Abstractions;

namespace Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase;

public class UpdateMenuItemUseCase(IMenuItemRepository repository, IUnitOfWork unitOfWork) : IUpdateMenuItemUseCase
{
    private IOutputPort? _outputPort;

    public void SetOutputPort(IOutputPort outputPort) => _outputPort = outputPort;

    public async Task ExecuteAsync(Guid id, Guid menuItemId, UpdateMenuItemRequest request,
        CancellationToken cancellationToken)
    {
        var restaurant = await repository.GetRestaurant(id, cancellationToken);
        if (restaurant is null)
        {
            _outputPort!.RestaurantNotFound();
        }

        var menuItem = await repository.GetMenuItem(menuItemId, cancellationToken);
        if (menuItem is null)
        {
            _outputPort!.MenuItemNotFound();
            return;
        }

        menuItem.Update(request);
        repository.UpdateMenuItem(menuItem);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        _outputPort!.MenuitemUpdated();
    }
}