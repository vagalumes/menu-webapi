using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Models;

namespace Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Abstractions
{
    public interface IUpdateRestaurantUseCase
    {
        void SetOutputPort(IOutputPort outputPort);
        Task ExecuteAsync(Guid id, UpdateRestaurantRequest request, CancellationToken cancellationToken);
    }
}
