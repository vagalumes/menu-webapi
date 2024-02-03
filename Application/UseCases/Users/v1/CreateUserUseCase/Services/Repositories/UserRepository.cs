using Application.Shared.Context;
using Application.UseCases.Users.v1.CreateUserUseCase.Services.Repositories.Abstractions;

namespace Application.UseCases.Users.v1.CreateUserUseCase.Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) => _context = context;

        public bool UserExists(long cpf) => _context.Users.Any(u => u.CPF == cpf);
        public async Task CreateUser(Shared.Entities.User user, CancellationToken cancellationToken) => await _context.Users.AddAsync(user, cancellationToken);

    }
}
