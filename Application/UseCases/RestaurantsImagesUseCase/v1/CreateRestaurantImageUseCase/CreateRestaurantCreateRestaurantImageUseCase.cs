using Application.Shared.Entities;
using Application.Shared.Services.Abstractions;
using Application.UseCases.RestaurantsImagesUseCase.v1.CreateRestaurantImageUseCase.Abstractions;
using Application.UseCases.RestaurantsImagesUseCase.v1.CreateRestaurantImageUseCase.Services.Repositories.Abstractions;
using Microsoft.AspNetCore.Http;

namespace Application.UseCases.RestaurantsImagesUseCase.v1.CreateRestaurantImageUseCase
{
    public class CreateRestaurantCreateRestaurantImageUseCase(IImageRepository imageRepository, IImagesService imagesService, IUnitOfWork unitOfWork)
        : ICreateRestaurantImageUseCase
    {
        private IOutputPort? _outputPort;
        public void SetOutputPort(IOutputPort outputPort) => _outputPort = outputPort;

        public async Task ExecuteAsync(Guid id, IFormFile file, CancellationToken cancellationToken)
        {
            var restaurant = await imageRepository.GetRestaurant(id, cancellationToken);
            if (restaurant is null)
            {
                _outputPort!.RestaurantNotFound();
                return;
            }

            var fileInfo = await imagesService.UploadFile($"restaurant-{id}", file, cancellationToken);

            await AddImage(restaurant, fileInfo, cancellationToken);

            _outputPort!.ImagesSaved();
        }

        private async Task AddImage(Restaurant restaurant, FileInfo file, CancellationToken cancellationToken)
        {
            restaurant.Images.Add(new RestaurantsImages
            {
                Extension = file.Extension,
                Name = file.Name,
                Path = file.ToString()
            });
            restaurant.ProfileImage = file.ToString();
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}