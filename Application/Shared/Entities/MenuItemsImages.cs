using Application.Shared.Interfaces;

namespace Application.Shared.Entities
{
    public class MenuItemsImages() : IImage
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }

        public MenuItem MenuItem { get; set; }
    }
}
