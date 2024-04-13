using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Shared.Entities
{
    public class MenuItem()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Price { get; set; }

        public ICollection<MenuItemsImages> Images { get; set; } = [];

        public Restaurant Restaurant { get; set; } = null!;

        public MenuItem(CreateMenuItemsRequest request, Restaurant restaurant) : this()
        {
            Name = request.Name;
            Description = request.Description;
            Price = request.Price;

            Restaurant = restaurant;
        }
    }
}
