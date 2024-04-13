namespace Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Models
{
    public class UpdateScheduleInformation
    {
        public DayOfWeek Day { get; set; }
        public TimeOnly Start { get; set; }
        public TimeOnly End { get; set; }
    }
}
