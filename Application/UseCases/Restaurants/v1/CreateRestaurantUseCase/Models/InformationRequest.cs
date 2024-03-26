﻿namespace Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Models
{
    public class InformationRequest
    {
        public string? Description { get; set; }
        public IEnumerable<ScheduleRequest> Schedule { get; set; } = Enumerable.Empty<ScheduleRequest>();
    }
}
