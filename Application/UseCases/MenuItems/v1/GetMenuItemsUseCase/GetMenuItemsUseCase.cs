using Application.UseCases.MenuItems.v1.GetMenuItemsUseCase.Abstractions;
using Application.UseCases.MenuItems.v1.GetMenuItemsUseCase.Models;
using Application.UseCases.MenuItems.v1.GetMenuItemsUseCase.Services.Repositories.Abstractions;

namespace Application.UseCases.MenuItems.v1.GetMenuItemsUseCase
{
    public class GetMenuItemsUseCase(IMenuItemsRepository repository) : IGetMenuItemsUseCase
    {
        private IOutputPort? _outputPort;

        public void SetOutputPort(IOutputPort outputPort) => _outputPort = outputPort;

        public async Task ExecuteAsync(Guid id, CancellationToken cancellationToken)
        {
            var restaurant = await repository.GetRestaurant(id, cancellationToken);
            if (restaurant is null)
            {
                _outputPort!.RestaurantNotFound();
                return;
            }

            var menuItems = GetMenuItemsResponse(id);

            _outputPort!.MenuItemsFound(menuItems);
        }

        private IEnumerable<MenuItemsResponse> GetMenuItemsResponse(Guid id)
        {
            var menuItems = repository.GetMenuItems(id);
            return menuItems.Select(item => new MenuItemsResponse(item));
        }
    }
}
