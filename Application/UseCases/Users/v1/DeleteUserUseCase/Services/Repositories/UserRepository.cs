using Application.Shared.Context;
using Application.Shared.Entities;
using Application.UseCases.Users.v1.DeleteUserUseCase.Services.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Users.v1.DeleteUserUseCase.Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext appDbContext) => _context = appDbContext;

        public void DeletedUser(User user) => _context.Remove(user);

        public async Task<User?> GetUser(Guid userId, CancellationToken cancellationToken) =>
               await _context.Users.Include(u => u.Adress)
                                   .Include(u => u.Login)
                                   .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
    }
}
