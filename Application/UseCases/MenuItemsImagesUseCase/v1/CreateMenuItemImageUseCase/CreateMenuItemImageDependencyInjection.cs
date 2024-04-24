using Application.UseCases.MenuItemsImagesUseCase.v1.CreateMenuItemImageUseCase.Abstractions;
using Application.UseCases.MenuItemsImagesUseCase.v1.CreateMenuItemImageUseCase.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.MenuItemsImagesUseCase.v1.CreateMenuItemImageUseCase
{
    public static class CreateMenuItemImageDependencyInjection
    {
        public static IServiceCollection AddCreateMenuItemsImageUseCase(this IServiceCollection services)
        {
            return services.AddImageDependencies()
                           .AddScoped<ICreateMenuItemImage, MenuItemsImagesUseCase.v1.CreateMenuItemImageUseCase.CreateMenuItemImageUseCase>();
        }
    }
}
