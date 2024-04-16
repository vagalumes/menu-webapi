namespace Application.UseCases.MenuItems.v1.GetMenuItemsUseCase.Abstractions
{
    public interface IGetMenuItemsUseCase
    {
        void SetOutputPort(IOutputPort outputPort);

        Task ExecuteAsync(Guid id, CancellationToken cancellationToken);
    }
}
