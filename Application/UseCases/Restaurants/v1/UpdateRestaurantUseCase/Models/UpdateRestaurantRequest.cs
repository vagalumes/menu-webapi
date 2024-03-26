
using Application.Shared.Models.Request;

namespace Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Models
{
    public class UpdateRestaurantRequest
    {
        public string? Name { get; set; }
        public List<OpeningHoursRequest> ServiceHours { get; set; } = [];
        public LoginRequest LoginRequest { get; set; } = new LoginRequest();
        public PaymentRequest PaymentRequest { get; set; } = new PaymentRequest();
    }
}
