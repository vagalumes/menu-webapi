using Application.Shared.Context;
using Application.UseCases.Users.v1.CreateUserUseCase.Services.Repositories.Abstractions;

namespace Application.UseCases.Users.v1.CreateUserUseCase.Services.Repositories
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        public bool UserExists(long cpf) => context.Users.Any(u => u.CPF == cpf);
        public async Task CreateUser(Shared.Entities.User user, CancellationToken cancellationToken) => await context.Users.AddAsync(user, cancellationToken);

    }
}
