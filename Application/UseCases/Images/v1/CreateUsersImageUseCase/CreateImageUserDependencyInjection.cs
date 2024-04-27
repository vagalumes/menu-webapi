using Application.UseCases.Images.v1.CreateUsersImageUseCase.Abstractions;
using Application.UseCases.Images.v1.CreateUsersImageUseCase.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.Images.v1.CreateUsersImageUseCase;

public static class CreateImageUserDependencyInjection
{
    public static IServiceCollection AddCreateUserImageUseCase(this IServiceCollection services)
    {
        return services.AddScoped<ICreateUserImageUseCase, CreateUserImageUseCase>().AddImagesDependencies();
    }
}