using Application.Shared.Entities;

namespace Application.UseCases.Restaurants.v1.GetRestaurantUsecase.Models;

public record GetInformationModel
{
    public GetInformationModel(Information information)
    {
        Id = information.Id;
        Description = information.Description;
        Schedules = information.Schedules.Select(schedule => new GetSchedulesModel(schedule)).ToList();
    }

    public Guid Id { get; init; }
    public string? Description { get; init; }
    public ICollection<GetSchedulesModel> Schedules { get; init; }
}