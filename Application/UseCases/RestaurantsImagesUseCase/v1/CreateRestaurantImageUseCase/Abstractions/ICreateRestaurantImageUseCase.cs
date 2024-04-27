using Microsoft.AspNetCore.Http;

namespace Application.UseCases.RestaurantsImagesUseCase.v1.CreateRestaurantImageUseCase.Abstractions
{
    public interface ICreateRestaurantImageUseCase
    {
        Task ExecuteAsync(Guid id, IFormFile file, CancellationToken cancellationToken);
        void SetOutputPort(IOutputPort outputPort);
    }
}
