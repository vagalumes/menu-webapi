using Application.Shared.Entities;
using Application.Shared.Services.Abstractions;
using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Abstractions;
using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Models;
using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Services.Repositories.Abstractions;

namespace Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase
{
    public class CreateMenuItemUseCase(IMenuItemRepository repository, IUnitOfWork unitOfWork) : ICreateMenuItemsUseCase
    {
        private IOutputPort? _outputPort;

        public void SetOutputPort(IOutputPort outputPort) => _outputPort = outputPort;

        public async Task ExecuteAsync(Guid id, CreateMenuItemsRequest request, CancellationToken cancellationToken)
        {
            var restaurant = await repository.GetRestaurant(id, cancellationToken);
            if (restaurant is null)
            {
                _outputPort!.RestaurantNotFound("Restaurante não localizado!");
                return;
            }

            var menuItem = await SaveMenuItem(request, restaurant, cancellationToken);
            _outputPort!.MenuItemsCreated(menuItem);
        }

        private async Task<MenuItemResponse> SaveMenuItem(CreateMenuItemsRequest request, Restaurant restaurant,
            CancellationToken cancellationToken)
        {
            var menuItem = new MenuItem(request, restaurant);
            await repository.CreateMenuItems(menuItem, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            var response = new MenuItemResponse(menuItem);
            return response;
        }
    }
}