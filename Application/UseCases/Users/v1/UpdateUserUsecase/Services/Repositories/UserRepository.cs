using Application.Shared.Context;
using Application.Shared.Entities;
using Application.UseCases.Users.v1.UpdateUserUseCase.Services.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Users.v1.UpdateUserUseCase.Services.Repositories;

public class UserRepository(AppDbContext dbContext) : IUserRepository
{
    public async Task<User?> GetUser(Guid userId, CancellationToken cancellationToken)
    {
        return await dbContext.Users.Include(u => u.Address)
            .Include(u => u.Login)
            .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
    }

    public async Task<bool> UserExists(Guid userId)
    {
        return await dbContext.Users.AnyAsync(u => u.Id == userId);
    }
}