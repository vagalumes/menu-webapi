using Application.Shared.Interfaces;

namespace Application.Shared.Entities
{
    public class MenuItemsImages() : IImage
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public string Extension { get; set; } = string.Empty;

        public MenuItem MenuItem { get; set; } = null!;
    }
}
