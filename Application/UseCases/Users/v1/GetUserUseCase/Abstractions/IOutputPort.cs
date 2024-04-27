using Application.UseCases.Users.v1.GetUserUseCase.Model;

namespace Application.UseCases.Users.v1.GetUserUseCase.Abstractions;

public interface IOutputPort
{
    void UserNotFound();
    void UserFound(GetUserModel userModel);
}