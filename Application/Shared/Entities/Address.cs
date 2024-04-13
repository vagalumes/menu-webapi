using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Models;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Shared.Entities
{
    public class Address()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? Street { get; set; }
        public string? Neighborhood { get; set; }
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string? Complement { get; set; }
        public string ZipCode { get; set; } = string.Empty;
        public string? Number { get; set; }

        public Guid RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } = null!;

        public Address(AddressRequest address) : this()
        {
            Street = address.Street;
            Neighborhood = address.Neighborhood;
            City = address.City;
            State = address.State;
            Complement = address.Complement;
            ZipCode = address.ZipCode;
            Number = address.Number;
        }

        public void Update(UpdateAddressRequest? address)
        {
            Street = address?.Street ?? Street;
            Neighborhood = address?.Neighborhood ?? Neighborhood;
            City = address?.City ?? City;
            State = address?.State ?? State;
            Complement = address?.Complement ?? Complement;
            ZipCode = address?.ZipCode ?? ZipCode;
            Number = address?.Number ?? Number;
        }
    }
}
