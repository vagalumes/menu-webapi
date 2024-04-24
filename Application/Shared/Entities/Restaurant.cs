using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Models;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Models;

namespace Application.Shared.Entities;

public class Restaurant()
{
    public Restaurant(CreateRestaurantRequest request) : this()
    {
        Name = request.Name;
        Cnpj = request.Cnpj;
        Information = new Information(request.Information);
        Address = new Address(request.Address);
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public Information Information { get; set; } = null!;
    public Address Address { get; set; } = null!;
    public ICollection<MenuItem> MenuItems { get; set; } = [];
    public ICollection<RestaurantsImages> Images { get; set; } = [];
    public string ProfileImage { get; set; } = string.Empty;

    public void Update(UpdateRestaurantRequest request)
    {
        Name = request.Name ?? Name;

        Address.Update(request.Address);
        Information.Update(request.Information);
    }
}