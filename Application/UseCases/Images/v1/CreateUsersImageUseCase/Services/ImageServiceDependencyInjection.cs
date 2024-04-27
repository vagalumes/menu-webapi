using Application.UseCases.Images.v1.CreateUsersImageUseCase.Services.Repositories;
using Application.UseCases.Images.v1.CreateUsersImageUseCase.Services.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.Images.v1.CreateUsersImageUseCase.Services;

public static class ImageServiceDependencyInjection
{
    public static IServiceCollection AddImagesDependencies(this IServiceCollection services)
    {
        return services.AddScoped<IImageRepository, ImageRepository>();
    }
}