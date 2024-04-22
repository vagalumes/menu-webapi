namespace Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Models
{
    public class CreateMenuItemsRequest
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
