using Application.UseCases.Images.v1.CreateMenuItemImageUseCase.Abstractions;
using Application.UseCases.Images.v1.CreateMenuItemImageUseCase.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.Images.v1.CreateMenuItemImageUseCase
{
    public static class CreateMenuItemImageDependencyInjection
    {
        public static IServiceCollection AddMenuItemsImageUseCase(this IServiceCollection services)
        {
            return services.AddImageDependencies()
                           .AddScoped<ICreateMenuItemImage, CreateMenuItemImageUseCase>();
        }
    }
}
