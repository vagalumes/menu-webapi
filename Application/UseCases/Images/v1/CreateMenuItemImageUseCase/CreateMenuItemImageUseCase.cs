using Application.Shared.Entities;
using Application.Shared.Services.Abstractions;
using Application.UseCases.Images.v1.CreateMenuItemImageUseCase.Abstractions;
using Application.UseCases.Images.v1.CreateMenuItemImageUseCase.Services.Repositories.Abstractions;
using Application.UseCases.Images.v1.UploadService.Services.Abstractions;
using Microsoft.AspNetCore.Http;

namespace Application.UseCases.Images.v1.CreateMenuItemImageUseCase
{
    public class CreateMenuItemImageUseCase(IImageRepository repository, IUploadService service, IUnitOfWork unitOfWork) : ICreateMenuItemImage
    {
        private IOutputPort? _outputPort;
        public void SetOutputPort(IOutputPort outputPort) => _outputPort = outputPort;
        public async Task ExecuteAsync(Guid id, IEnumerable<IFormFile> files, CancellationToken cancellationToken)
        {
            var menu = await repository.GetMenuItem(id, cancellationToken);
            if (menu is null)
            {
                _outputPort!.MenuNotFound();
                return;
            }

            var filesInfo = await service.UploadFiles($"menuItem-{id}", files, cancellationToken);
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
                    Path = file.FullName
                });
            }

            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

    }
}
