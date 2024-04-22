using Application.Shared.Entities;

namespace Application.UseCases.MenuItems.v1.GetMenuItemsUseCase.Models
{
    public class MenuItemsResponse(MenuItem menuItem)
    {
        public Guid Id { get; set; } = menuItem.Id;
        public string Name { get; set; } = menuItem.Name;
        public string Description { get; set; } = menuItem.Description;
        public decimal Price { get; set; } = menuItem.Price;

        public IEnumerable<MenuItemsImagesResponse> Images { get; set; } = menuItem.Images.Select(item => new MenuItemsImagesResponse(item));
    }
}
