namespace Application.UseCases.Users.v1.UpdateUserUsecase.Abstraction;

public interface IOutputPort
{
    void UserNotFound();
    void InvalidRequest();
    void UserUpdated();
}