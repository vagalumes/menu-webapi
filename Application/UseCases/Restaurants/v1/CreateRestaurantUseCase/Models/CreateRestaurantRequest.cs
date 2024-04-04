
namespace Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Models
{

    public class CreateRestaurantRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public AddressRequest Address { get; set; } = null!;
        //public InformationRequest Information { get; set; } = null!;
    }
}
