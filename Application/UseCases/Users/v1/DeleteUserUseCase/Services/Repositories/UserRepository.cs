using Application.Shared.Context;
using Application.Shared.Entities;
using Application.UseCases.Users.v1.DeleteUserUseCase.Services.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Users.v1.DeleteUserUseCase.Services.Repositories
{
    public class UserRepository(AppDbContext appDbContext) : IUserRepository
    {
        public void DeletedUser(User user) => appDbContext.Remove(user);

        public async Task<User?> GetUser(Guid userId, CancellationToken cancellationToken) =>
               await appDbContext.Users.Include(u => u.Adress)
                                   .Include(u => u.Login)
                                   .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
    }
}
