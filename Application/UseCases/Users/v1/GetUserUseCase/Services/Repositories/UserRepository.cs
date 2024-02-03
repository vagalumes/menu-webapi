using Application.Shared.Context;
using Application.Shared.Entities;
using Application.UseCases.Users.v1.GetUserUseCase.Services.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Users.v1.GetUserUseCase.Services.Repositories
{
    public class UserRepository(AppDbContext dbContext) : IUserRepository
    {
        public async Task<User?> GetUserUseCase(Guid userId, CancellationToken cancellationToken) =>
               await dbContext.Users.Include(u => u.Adress)
                                   .Include(u => u.Login)
                                   .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
    }
}
