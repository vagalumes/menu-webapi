using Application.Shared.Entities;

namespace Application.UseCases.Restaurants.v1.GetRestaurantUseCase.Models;

public record GetSchedulesModel
{
    public Guid Id { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly Start { get; set; }
    public TimeOnly End { get; set; }

    public GetSchedulesModel(Schedule schedule)
    {
        Id = schedule.Id;
        DayOfWeek = schedule.DayOfWeek;
        Start = schedule.Start;
        End = schedule.End;
    }
}