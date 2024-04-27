namespace Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Models;

public class UpdateRestaurantRequest
{
    public string? Name { get; set; }
    public UpdateAddressRequest? Address { get; set; }
    public UpdateInformationRequest? Information { get; set; }
}