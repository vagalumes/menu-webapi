using Application.Shared.Entities;

namespace Application.UseCases.Users.v1.DeleteUserUseCase.Services.Repositories.Abstractions;

public interface IUserRepository
{
    void DeletedUser(User user);
    Task<User?> GetUser(Guid userId, CancellationToken cancellationToken);
}