namespace Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Models
{
    public class ScheduleRequest
    {
        public DayOfWeek Day { get; set; }
        public TimeOnly Start { get; set; }
        public TimeOnly End { get; set; }
    }
}
