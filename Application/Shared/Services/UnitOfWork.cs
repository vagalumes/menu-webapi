using Application.Shared.Context;
using Application.Shared.Services.Abstractions;

namespace Application.Shared.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public UnitOfWork(AppDbContext dbContext) => _dbContext = dbContext;
        public async Task SaveChangesAsync(CancellationToken cancellationToken) => await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
