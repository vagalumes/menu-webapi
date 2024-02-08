using Application.Shared.Models.Request;

namespace Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Models
{
    public class UpdateRestaurantRequest
    {
        public string? Name { get; set; }
        public List<ScheduleRequest> ServiceHours { get; set; } = new List<ScheduleRequest>();
        public InformationRequest InformationRequest { get; set; } = new InformationRequest();
        public LoginRequest LoginRequest { get; set; } = new LoginRequest();
        public PaymentRequest PaymentRequest { get; set; } = new PaymentRequest();
        public AdressRequest AdressRequest { get; set; } = new AdressRequest();
    }
}
