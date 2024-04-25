using Application.Shared.Entities;
using Application.Shared.Services.Abstractions;
using Application.UseCases.MenuItemsImagesUseCase.v1.CreateMenuItemImageUseCase.Abstractions;
using Application.UseCases.MenuItemsImagesUseCase.v1.CreateMenuItemImageUseCase.Services.Repositories.Abstractions;
using Microsoft.AspNetCore.Http;

namespace Application.UseCases.MenuItemsImagesUseCase.v1.CreateMenuItemImageUseCase
{
    public class CreateMenuItemImageUseCase(IImageRepository repository, IImagesService service, IUnitOfWork unitOfWork) : ICreateMenuItemImage
    {
        private IOutputPort? _outputPort;
        public void SetOutputPort(IOutputPort outputPort) => _outputPort = outputPort;
        public async Task ExecuteAsync(Guid id, Guid menuItemId, IEnumerable<IFormFile> files, CancellationToken cancellationToken)
        {
            var restaurant = await repository.GetRestaurant(id, cancellationToken);
            if (restaurant is null)
            {
                _outputPort!.RestaurantNotFound();
                return;
            }

            var menu = await repository.GetMenuItem(menuItemId, cancellationToken);
            if (menu is null)
            {
                _outputPort!.MenuNotFound();
                return;
            }

            var filesInfo = await service.UploadFiles($"menuItem-{menuItemId}", files, cancellationToken);
            await AddImages(menu, filesInfo, cancellationToken);
            _outputPort!.ImageSaved();
        }

        private async Task AddImages(MenuItem menu, IEnumerable<FileInfo> fileInfos,
            CancellationToken cancellationToken)
        {
            foreach (var file in fileInfos)
            {
                menu.Images.Add(new MenuItemsImages
                {
                    Extension = file.Extension,
                    Name = file.Name,
                    Path = file.ToString()
                });
            }

            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

    }
}
