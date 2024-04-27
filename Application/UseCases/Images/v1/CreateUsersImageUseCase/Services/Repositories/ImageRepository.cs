using Application.Shared.Context;
using Application.Shared.Entities;
using Application.UseCases.Images.v1.CreateUsersImageUseCase.Services.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Images.v1.CreateUsersImageUseCase.Services.Repositories;

public class ImageRepository(AppDbContext dbContext) : IImageRepository
{
    public async Task<User?> GetUser(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }
}