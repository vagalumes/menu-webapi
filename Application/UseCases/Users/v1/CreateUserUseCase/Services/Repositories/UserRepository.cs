using Application.Shared.Context;
using Application.Shared.Entities;
using Application.UseCases.Users.v1.CreateUserUseCase.Services.Repositories.Abstractions;

namespace Application.UseCases.Users.v1.CreateUserUseCase.Services.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public bool UserExists(long cpf)
    {
        return context.Users.Any(u => u.Cpf == cpf);
    }

    public async Task CreateUser(User user, CancellationToken cancellationToken)
    {
        await context.Users.AddAsync(user, cancellationToken);
    }
}