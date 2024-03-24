using Application.Shared.Entities;
using Application.Shared.Services.Abstractions;
using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Abstractions;
using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Models;
using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Services.Repositories.Abstractions;
using Application.UseCases.Restaurants.v1.GetRestaurantUseCase.Services.Repositories.Abstractions;

namespace Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase
{
    public class CreateMenuItemUseCase(IMenuItemRepository repository, IUnitOfWork unitOfWork, IRestaurantRepository restaurantRepository) : ICreateMenuItemsUseCase
    {
        private IOutputPort? _outputPort;

        public void SetOutputPort(IOutputPort outputPort) => _outputPort = outputPort;

        public async Task ExecuteAsync(Guid id, CreateMenuItemsRequest request, CancellationToken cancellationToken)
        {
            var restaurant = await restaurantRepository.GetRestaurant(id, cancellationToken);
            if (restaurant is null)
            {
                _outputPort!.RestaurantNotFound("Restaurante não localizado!");
                return;
            }

            var menuItem = await SaveMenuItem(request, restaurant!, cancellationToken);
            _outputPort!.MenuItemsCreated(menuItem);
        }

        private async Task<MenuItem> SaveMenuItem(CreateMenuItemsRequest request, Restaurant restaurant, CancellationToken cancellationToken)
        {
            var menuItem = new MenuItem(request, restaurant);
            await repository.CreateMenuItems(menuItem, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return menuItem;
        }
    }
}
