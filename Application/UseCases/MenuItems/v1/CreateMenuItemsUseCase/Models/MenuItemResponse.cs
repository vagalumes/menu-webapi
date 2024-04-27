using Application.Shared.Entities;

namespace Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Models;

public class MenuItemResponse()
{
    public Guid Id { get; set; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public decimal Price { get; init; }

    public MenuItemResponse(MenuItem menuItem) : this()
    {
        Id = menuItem.Id;
        Name = menuItem.Name;
        Description = menuItem.Description;
        Price = menuItem.Price;
    }
}