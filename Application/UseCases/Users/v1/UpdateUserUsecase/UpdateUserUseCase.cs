using Application.Shared.Services.Abstractions;
using Application.UseCases.Users.v1.UpdateUserUseCase.Abstraction;
using Application.UseCases.Users.v1.UpdateUserUseCase.Models;
using Application.UseCases.Users.v1.UpdateUserUseCase.Services.Repositories.Abstractions;

namespace Application.UseCases.Users.v1.UpdateUserUseCase
{
    public class UpdateUserUseCase(IUserRepository repository, IUnitOfWork unitOfWork) : IUpdateUserUseCase
    {
        private IOutputPort? _outputPort;

        public void SetOutputPort(IOutputPort outputPort) => _outputPort = outputPort;

        public async Task ExecuteAsync(Guid userId, UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var user = await repository.GetUser(userId, cancellationToken);
            if (user is null)
            {
                _outputPort!.UserNotFound();
                return;
            }
            user.Update(request);
            user.Adress.Update(request.Adress);
            user.Login.Update(request.Access);

            await unitOfWork.SaveChangesAsync(cancellationToken);
            _outputPort!.UserUpdated();
        }
    }
}
