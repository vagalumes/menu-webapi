using Application.Shared.Entities;

namespace Application.UseCases.Users.v1.UpdateUserUseCase.Services.Repositories.Abstractions;

public interface IUserRepository
{
    Task<User?> GetUser(Guid userId, CancellationToken cancellationToken);
    Task<bool> UserExists(Guid userId);
}