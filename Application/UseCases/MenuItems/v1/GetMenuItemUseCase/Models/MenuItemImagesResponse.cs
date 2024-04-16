using Application.Shared.Entities;

namespace Application.UseCases.MenuItems.v1.GetMenuItemUseCase.Models
{
    public class MenuItemImagesResponse(MenuItemsImages image)
    {
        public string Name { get; set; } = image.Name;
        public string Path { get; set; } = image.Path;
        public string Extension { get; set; } = image.Extension;
    }
}
