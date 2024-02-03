using Application.Shared.Models.Request;

namespace Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Models
{

    public class CreateRestaurantRequest
    {
        public string Name { get; set; } = null!;
        public long CNPJ { get; set; }
        public List<OpeningHoursRequest>? ServiceHours { get; set; }
        public AdressRequest AdressRequest { get; set; } = null!;
        public InformationRequest? InformationRequest { get; set; }
        public LoginRequest LoginRequest { get; set; } = null!;
        public PaymentRequest PaymentRequest { get; set; } = null!;
    }
}
