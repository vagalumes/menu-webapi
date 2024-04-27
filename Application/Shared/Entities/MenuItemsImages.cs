using Application.Shared.Interfaces;

namespace Application.Shared.Entities;

public class MenuItemsImages : Image
{
    public Guid Id { get; set; }
    public Guid MenuItemId { get; set; }
    public MenuItem MenuItem { get; set; } = null!;
}