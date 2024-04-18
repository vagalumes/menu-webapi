using Application.Shared.Entities;

namespace Application.UseCases.Restaurants.v1.GetRestaurantUseCase.Models;

public record GetInformationModel
{
    public Guid Id { get; init; }
    public string? Description { get; init; }
    public ICollection<GetSchedulesModel> Schedules { get; init; }

    public GetInformationModel(Information information)
    {
        Id = information.Id;
        Description = information.Description;
        Schedules = information.Schedules.Select(schedule => new GetSchedulesModel(schedule)).ToList();
    }
}