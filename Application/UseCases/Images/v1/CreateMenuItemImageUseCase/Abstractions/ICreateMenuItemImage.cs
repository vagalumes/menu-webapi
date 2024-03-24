using Microsoft.AspNetCore.Http;

namespace Application.UseCases.Images.v1.CreateMenuItemImageUseCase.Abstractions
{
    public interface ICreateMenuItemImage
    {
        void SetOutputPort(IOutputPort outputPort);
        Task ExecuteAsync(Guid id, IEnumerable<IFormFile> files, CancellationToken cancellationToken);
    }
}
