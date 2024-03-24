using Application.Shared.Entities;
using Application.Shared.Services.Abstractions;
using Application.UseCases.Images.v1.CreateRestaurantImageUseCase.Abstractions;
using Application.UseCases.Images.v1.CreateRestaurantImageUseCase.Services.Repositories.Abstractions;
using Application.UseCases.Images.v1.UploadService.Services.Abstractions;
using Microsoft.AspNetCore.Http;

namespace Application.UseCases.Images.v1.CreateRestaurantImageUseCase
{
    public class CreateRestaurantImageUseCase(IImageRepository imageRepository, IUploadService uploadService, IUnitOfWork unitOfWork) : ICreateImageUseCase
    {
        private IOutputPort? _outputPort;
        public void SetOutputPort(IOutputPort outputPort) => _outputPort = outputPort;

        public async Task ExecuteAsync(Guid id, IEnumerable<IFormFile> files, CancellationToken cancellationToken)
        {
            var restaurant = await imageRepository.GetRestaurant(id, cancellationToken);
            if (restaurant is null)
            {
                _outputPort!.RestaurantNotFound();
                return;
            }

            var filesInfo = await uploadService.UploadFiles($"restaurant-{id}", files, cancellationToken);

            await AddImages(restaurant, filesInfo, cancellationToken);

            _outputPort!.ImagesSaved(filesInfo);
        }

        private async Task AddImages(Restaurant restaurant, IEnumerable<FileInfo> fileInfos,
            CancellationToken cancellationToken)
        {
            foreach (var file in fileInfos)
            {
                restaurant.Images.Add(new Image
                {
                    Extension = file.Extension,
                    Name = file.Name,
                    Path = file.FullName
                });
            }

            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
