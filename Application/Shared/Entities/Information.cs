using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Models;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Models;

namespace Application.Shared.Entities;

public class Information()
{
    public Information(InformationRequest informationRequest) : this()
    {
        Description = informationRequest.Description;
        Schedules = informationRequest.Schedule.Select(x => new Schedule(x.Day, x.Start, x.End)).ToList();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string? Description { get; set; }
    public ICollection<Schedule> Schedules { get; set; } = [];
    public Guid RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; } = null!;

    public void Update(UpdateInformationRequest? information)
    {
        Description = information?.Description;

        if (information?.Schedule is null)
            return;

        Schedules = information.Schedule.Select(s => new Schedule(s.Day, s.Start, s.End)).ToList();
    }
}