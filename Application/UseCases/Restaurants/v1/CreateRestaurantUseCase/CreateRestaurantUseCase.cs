using Application.Shared.Entities;
using Application.Shared.Services.Abstractions;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Abstractions;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Models;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Services.Repositories.Abstractions;

namespace Application.UseCases.Restaurants.v1.CreateRestaurantUseCase
{
    public class CreateRestaurantUseCase(IRestaurantRepository repository, IUnitOfWork unitOfWork) : ICreateRestaurantUseCase
    {
        private IOutputPort? _outputPort;

        public void SetOutputPort(IOutputPort outputPort) => _outputPort = outputPort;

        public async Task ExecuteAsync(CreateRestaurantRequest request, CancellationToken cancellationToken)
        {
            var restaurant = await SaveRestaurant(request, cancellationToken);

            _outputPort!.RestaurantCreated(restaurant);
        }

        private async Task<RestaurantDto> SaveRestaurant(CreateRestaurantRequest request, CancellationToken cancellationToken)
        {
            var restaurant = new Restaurant(request, request.AdressRequest, request.InformationRequest!, request.LoginRequest, request.PaymentRequest, request.ServiceHours);

            await repository.CreateRestaurant(restaurant, cancellationToken);

            var restaurantDTO = new RestaurantDto(restaurant);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return restaurantDTO;
        }
    }
}
