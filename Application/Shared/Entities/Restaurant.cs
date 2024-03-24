using Application.Shared.Models.Request;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Models;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Shared.Entities
{
    public class Restaurant()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public long CNPJ { get; set; }
        public Information Information { get; set; } = new Information();
        public Login Login { get; set; } = null!;
        public Payments Payments { get; set; } = null!;
        public Adress Adress { get; set; } = null!;
        public List<OpeningHours> ServiceHours { get; set; } = new List<OpeningHours>();

        public IEnumerable<MenuItem> MenuItems { get; set; }

        public ICollection<Image> Images { get; set; } = new List<Image>();

        public Restaurant(CreateRestaurantRequest request, AdressRequest adressRequest, InformationRequest informationRequest, LoginRequest loginRequest, PaymentRequest paymentRequest, List<OpeningHoursRequest>? openingHoursRequest) : this()
        {
            Name = request.Name;
            CNPJ = request.CNPJ;
            Adress = new Adress(adressRequest);
            Information = new Information(informationRequest);
            Login = new Login(loginRequest);
            Payments = new Payments(paymentRequest);
            if (openingHoursRequest != null && openingHoursRequest.Any())
                ServiceHours = openingHoursRequest.Select(oh => new OpeningHours(oh)).ToList();
        }

        public void Update(UpdateRestaurantRequest request) => Name = request.Name ?? Name;
    }
}
