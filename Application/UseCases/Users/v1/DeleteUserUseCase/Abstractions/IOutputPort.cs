namespace Application.UseCases.Users.v1.DeleteUserUseCase.Abstractions
{
    public interface IOutputPort
    {
        void UserDeleted();
        void UserNotFound();
    }
}
