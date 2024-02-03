namespace Application.UseCases.Users.v1.DeleteUserUseCase.Abstractions
{
    public interface IDeleteUserUseCase
    {
        void SetOutputPort(IOutputPort outputPort);
        Task ExecuteAsync(Guid userId, CancellationToken cancellationToken);
    }
}
