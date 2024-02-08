using System.ComponentModel.DataAnnotations.Schema;
using Application.Shared.Models.Request;

namespace Application.Shared.Entities
{
    public class Schedule
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeOnly OpeningTime { get; set; }
        public TimeOnly ClosingTime { get; set; }

        public Guid RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } = null!;

        public Schedule() { }

        public Schedule(ScheduleRequest scheduleRequest)
        {
            DayOfWeek = scheduleRequest.DayOfWeek;
            OpeningTime = scheduleRequest.OpeningTime;
            ClosingTime = scheduleRequest.ClosingTime;
        }
    }
}
