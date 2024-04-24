namespace Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Models;

public class UpdateInformationRequest
{
    public string? Description { get; set; }
    public IEnumerable<UpdateScheduleInformation> Schedule { get; set; } = [];
}