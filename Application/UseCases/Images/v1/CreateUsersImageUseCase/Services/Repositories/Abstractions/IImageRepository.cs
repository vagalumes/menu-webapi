using Application.Shared.Entities;

namespace Application.UseCases.Images.v1.CreateUsersImageUseCase.Services.Repositories.Abstractions;

public interface IImageRepository
{
    Task<User?> GetUser(Guid id, CancellationToken cancellationToken);
}