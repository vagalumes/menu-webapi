using Application.UseCases.Users.v1.GetUserUseCase.Services.Repositories;
using Application.UseCases.Users.v1.GetUserUseCase.Services.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.Users.v1.GetUserUseCase.Services
{
    public static class UserServicesDependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services) => services.AddScoped<IUserRepository, UserRepository>();
    }
}
