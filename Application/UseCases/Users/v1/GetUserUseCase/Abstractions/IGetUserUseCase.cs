namespace Application.UseCases.Users.v1.GetUserUseCase.Abstractions
{
    public interface IGetUserUseCase
    {
        void SetOutputPort(IOutputPort outputPort);
        Task ExecuteAsync(Guid userId, CancellationToken cancellationToken);
    }
}
