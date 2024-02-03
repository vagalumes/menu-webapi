using Application.Shared.Services.Abstractions;
using Application.UseCases.Users.v1.CreateUserUseCase.Abstractions;
using Application.UseCases.Users.v1.CreateUserUseCase.Models;
using Application.UseCases.Users.v1.CreateUserUseCase.Services.Repositories.Abstractions;

namespace Application.UseCases.Users.v1.CreateUserUseCase
{
    public class CreateUserUseCase(IUserRepository repository, IUnitOfWork unitOfWork) : ICreateUsersUseCase
    {
        private IOutputPort? _outputPort;

        public void SetOutputPort(IOutputPort outputPort) => _outputPort = outputPort;

        public async Task ExecuteAsync(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = await SaveUser(request, cancellationToken);

            _outputPort!.UserCreated(user);
        }

        private async Task<UserDto> SaveUser(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = new Shared.Entities.User(request, request.Adress, request.Access);
            await repository.CreateUser(user, cancellationToken);
            var userDto = new UserDto(user);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return userDto;
        }
    }
}