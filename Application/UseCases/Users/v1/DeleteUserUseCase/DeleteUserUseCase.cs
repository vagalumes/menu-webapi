using Application.Shared.Entities;
using Application.Shared.Services.Abstractions;
using Application.UseCases.Users.v1.DeleteUserUseCase.Abstractions;
using Application.UseCases.Users.v1.DeleteUserUseCase.Services.Repositories.Abstractions;

namespace Application.UseCases.Users.v1.DeleteUserUseCase
{
    public class DeleteUserUseCase(IUserRepository repository, IUnitOfWork unitOfWork) : IDeleteUserUseCase
    {
        private IOutputPort? _outputPort;

        public void SetOutputPort(IOutputPort outputPort) => _outputPort = outputPort;

        public async Task ExecuteAsync(Guid userId, CancellationToken cancellationToken)
        {
            User? user = await repository.GetUser(userId, cancellationToken);
            if (user is null)
            {
                _outputPort!.UserNotFound();
                return;
            }
            repository.DeletedUser(user);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            _outputPort!.UserDeleted();
        }
    }
}
