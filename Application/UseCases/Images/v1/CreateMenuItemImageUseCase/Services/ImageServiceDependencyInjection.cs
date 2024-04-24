using Application.UseCases.Images.v1.CreateMenuItemImageUseCase.Services.Repositories;
using Application.UseCases.Images.v1.CreateMenuItemImageUseCase.Services.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.Images.v1.CreateMenuItemImageUseCase.Services;

public static class ImageServiceDependencyInjection
{
    public static IServiceCollection AddImageDependencies(this IServiceCollection services)
    {
        return services.AddScoped<IImageRepository, ImageRepository>();
    }
}