using Application.UseCases.Users.v1.UpdateUserUseCase.Models;

namespace Application.UseCases.Users.v1.UpdateUserUseCase.Abstraction
{
    public interface IUpdateUserUseCase
    {
        void SetOutputPort(IOutputPort outputPort);
        Task ExecuteAsync(Guid userId, UpdateUserRequest request, CancellationToken cancellationToken);
    }
}
