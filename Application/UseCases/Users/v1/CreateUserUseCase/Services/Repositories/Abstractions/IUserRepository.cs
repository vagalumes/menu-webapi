using Application.Shared.Entities;

namespace Application.UseCases.Users.v1.CreateUserUseCase.Services.Repositories.Abstractions
{
    public interface IUserRepository
    {
        bool UserExists(long cpf);

        Task CreateUser(User user, CancellationToken cancellationToken);
    }
}
