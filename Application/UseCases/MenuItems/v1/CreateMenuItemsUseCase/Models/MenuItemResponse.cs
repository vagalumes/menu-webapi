using Application.Shared.Entities;

namespace Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Models;

public class MenuItemResponse()
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public MenuItemResponse(MenuItem menuItem) : this()
    {
        Name = menuItem.Name;
        Description = menuItem.Description;
        Price = menuItem.Price;
    }
}