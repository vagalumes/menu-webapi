using Application.Shared.Notifications;
using Application.UseCases.Users.v1.CreateUserUseCase.Abstractions;
using Application.UseCases.Users.v1.CreateUserUseCase.Models;
using Application.UseCases.Users.v1.CreateUserUseCase.Services.Repositories.Abstractions;

namespace Application.UseCases.Users.v1.CreateUserUseCase
{
    public class CreateUserValidationUseCase(IUserRepository repository, ICreateUsersUseCase useCase, Notification notification) : ICreateUsersUseCase
    {
        private IOutputPort? _outputPort;

        public void SetOutputPort(IOutputPort outputPort)
        {
            _outputPort = outputPort;
            useCase.SetOutputPort(outputPort);
        }

        public async Task ExecuteAsync(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var checkUser = repository.UserExists(request.CPF);

            if (checkUser)
                notification.AddErrorMessage(nameof(request.CPF), "CPF já cadastrado");

            if (notification.IsInvalid)
            {
                _outputPort!.InvalidRequest();
                return;
            }

            await useCase.ExecuteAsync(request, cancellationToken);
        }
    }
}
