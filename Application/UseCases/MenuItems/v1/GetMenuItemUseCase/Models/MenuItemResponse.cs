using Application.Shared.Entities;

namespace Application.UseCases.MenuItems.v1.GetMenuItemUseCase.Models;

public class MenuItemResponse(MenuItem menuItem)
{
    public Guid Id { get; set; } = menuItem.Id;
    public string Name { get; set; } = menuItem.Name;
    public string Description { get; set; } = menuItem.Description;
    public decimal Price { get; set; } = menuItem.Price;

    public IEnumerable<MenuItemImagesResponse> Images { get; set; } =
        menuItem.Images.Select(item => new MenuItemImagesResponse(item));
}