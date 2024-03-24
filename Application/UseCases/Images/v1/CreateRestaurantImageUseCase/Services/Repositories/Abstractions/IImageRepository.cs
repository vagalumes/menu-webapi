using Application.Shared.Entities;

namespace Application.UseCases.Images.v1.CreateRestaurantImageUseCase.Services.Repositories.Abstractions
{
    public interface IImageRepository
    {
        Task<Restaurant?> GetRestaurant(Guid id, CancellationToken cancellationToken);
    }
}
