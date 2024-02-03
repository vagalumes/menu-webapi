using Application.UseCases.Users.v1.CreateUserUseCase.Models;

namespace Application.UseCases.Users.v1.CreateUserUseCase.Abstractions
{
    public interface IOutputPort
    {
        void InvalidRequest();
        void UserCreated(UserDto users);
    }
}
