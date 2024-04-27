using Application.UseCases.Users.v1.CreateUserUseCase.Models;

namespace Application.UseCases.Users.v1.CreateUserUseCase.Abstractions;

public interface ICreateUsersUseCase
{
    void SetOutputPort(IOutputPort outputPort);
    Task ExecuteAsync(CreateUserRequest request, CancellationToken cancellationToken);
}