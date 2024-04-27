using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Models;
using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Models;

namespace Application.Shared.Entities
{
    public class MenuItem()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; init; }

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }

        public ICollection<MenuItemsImages> Images { get; init; } = [];

        public Restaurant Restaurant { get; init; } = null!;

        public MenuItem(CreateMenuItemsRequest request, Restaurant restaurant) : this()
        {
            Name = request.Name;
            Description = request.Description;
            Price = request.Price;
            Restaurant = restaurant;
        }

        public void Update(UpdateMenuItemRequest request)
        {
            Name = request.Name ?? Name;
            Description = request.Description ?? Description;
            Price = request.Price ?? Price;
        }
    }
}