using Application.Shared.Entities;

namespace Application.UseCases.Users.v1.GetUserUseCase.Services.Repositories.Abstractions;

public interface IUserRepository
{
    Task<User?> GetUserUseCase(Guid userId, CancellationToken cancellationToken);
}