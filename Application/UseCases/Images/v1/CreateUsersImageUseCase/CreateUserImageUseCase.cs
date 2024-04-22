using Application.Shared.Entities;
using Application.Shared.Services.Abstractions;
using Application.UseCases.Images.v1.CreateUsersImageUseCase.Abstractions;
using Application.UseCases.Images.v1.CreateUsersImageUseCase.Services.Repositories.Abstractions;
using Microsoft.AspNetCore.Http;

namespace Application.UseCases.Images.v1.CreateUsersImageUseCase
{
    public class CreateUserImageUseCase(IImageRepository repository, IImagesService service, IUnitOfWork unitOfWork) : ICreateUserImageUseCase
    {
        private IOutputPort? _outputPort;

        public void SetOutputPort(IOutputPort outputPort) => _outputPort = outputPort;

        public async Task ExecuteAsync(Guid id, IEnumerable<IFormFile> files, CancellationToken cancellationToken)
        {
            var user = await repository.GetUser(id, cancellationToken);
            if (user is null)
            {
                _outputPort!.UserNotFound();
                return;
            }

            var filesInfo = await service.UploadFiles($"user-{id}", files, cancellationToken);
            await AddImages(user, filesInfo, cancellationToken);
            _outputPort!.ImageSaved();
        }

        private async Task AddImages(User user, IEnumerable<FileInfo> fileInfos,
            CancellationToken cancellationToken)
        {
            foreach (var file in fileInfos)
            {
                user.Images.Add(new UsersImages
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
