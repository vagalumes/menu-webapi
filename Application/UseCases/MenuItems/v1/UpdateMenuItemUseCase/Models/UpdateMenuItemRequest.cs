namespace Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Models;

public record UpdateMenuItemRequest
{
    public Guid Id { get; init; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
}