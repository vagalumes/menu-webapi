using Application.Shared.Models.Request;
using System.Text.Json.Serialization;

namespace Application.Shared.Entities
{
    public class OpeningHours
    {
        public Guid Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }

        public DateTime? OpeningTime2 { get; set; }
        public DateTime? ClosingTime2 { get; set; }

        [JsonIgnore]
        public Guid RestaurantId { get; set; }
        [JsonIgnore]
        public Restaurant Restaurant { get; set; } = null!;

        public OpeningHours() { }

        public OpeningHours(OpeningHoursRequest request)
        {
            DayOfWeek = request.DayOfWeek;
            OpeningTime = request.OpeningTime;
            ClosingTime = request.ClosingTime;
            OpeningTime2 = request.OpeningTime2;
            ClosingTime2 = request.ClosingTime2;

        }
    }
}
