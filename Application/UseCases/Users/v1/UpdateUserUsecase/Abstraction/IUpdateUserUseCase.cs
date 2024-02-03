using Application.UseCases.Users.v1.UpdateUserUsecase.Models;

namespace Application.UseCases.Users.v1.UpdateUserUsecase.Abstraction
{
    public interface IUpdateUserUseCase
    {
        void SetOutputPort(IOutputPort outputPort);
        Task ExecuteAsync(Guid userId, UpdateUserRequest request, CancellationToken cancellationToken);
    }
}
