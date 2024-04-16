using Application.UseCases.MenuItems.v1.GetMenuItemUseCase.Abstractions;
using Application.UseCases.MenuItems.v1.GetMenuItemUseCase.Models;
using Application.UseCases.MenuItems.v1.GetMenuItemUseCase.Services.Repositories.Abstractions;

namespace Application.UseCases.MenuItems.v1.GetMenuItemUseCase
{
    public class GetMenuItemUseCase(IMenuItemRepository repository) : IGetMenuItemUseCase
    {
        private IOutputPort? _outputPort;

        public void SetOutputPort(IOutputPort outputPort) => _outputPort = outputPort;

        public async Task ExecuteAsync(Guid id, Guid menuItemId, CancellationToken cancellationToken)
        {
            var restaurant = await repository.GetRestaurant(id, cancellationToken);
            if (restaurant is null)
            {
                _outputPort!.RestaurantNotFound();
                return;
            }

            var menuItem = await repository.GetMenuItem(menuItemId, cancellationToken);
            if (menuItem is null)
            {
                _outputPort!.MenuItemNotFound();
                return;
            }

            _outputPort!.MenuItemFound(new MenuItemResponse(menuItem));
        }
    }
}
