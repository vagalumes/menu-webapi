using Application.UseCases.Users.v1.GetUserUseCase.Abstractions;
using Application.UseCases.Users.v1.GetUserUseCase.Model;
using Application.UseCases.Users.v1.GetUserUseCase.Services.Repositories.Abstractions;

namespace Application.UseCases.Users.v1.GetUserUseCase
{
    public class GetUserUseCase(IUserRepository repository) : IGetUserUseCase
    {
        private IOutputPort? _outputPort;

        public void SetOutputPort(IOutputPort outputPort) => _outputPort = outputPort;

        public async Task ExecuteAsync(Guid userId, CancellationToken cancellationToken)
        {
            var user = await repository.GetUserUseCase(userId, cancellationToken);

            if (user is null)
            {
                _outputPort!.UserNotFound();
                return;
            }

            var userModel = new GetUserModel(user);

            _outputPort!.UserFound(userModel);
        }
    }
}
