using Application.Shared.Entities;

namespace Application.UseCases.Images.v1.CreateMenuItemImageUseCase.Services.Repositories.Abstractions
{
    public interface IImageRepository
    {
        Task<MenuItem?> GetMenuItem(Guid id, CancellationToken cancellationToken);
    }
}
