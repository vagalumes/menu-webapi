using Application.UseCases.Users.v1.DeleteUserUseCase.Services.Repositories;
using Application.UseCases.Users.v1.DeleteUserUseCase.Services.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.Users.v1.DeleteUserUseCase.Services
{
    public static class UserServicesDependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services) => services.AddScoped<IUserRepository, UserRepository>();
    }
}
