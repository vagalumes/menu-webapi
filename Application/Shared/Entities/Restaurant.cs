using System.Collections.ObjectModel;
using Application.Shared.Models.Request;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Models;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Shared.Entities
{
    public class Restaurant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public long Cnpj { get; set; }
        public Information Information { get; set; } = new Information();
        public Login Login { get; set; } = null!;
        public Payments Payments { get; set; } = null!;
        public Address Address { get; set; } = null!;
        public ICollection<Schedule> Schedules { get; set; } = new Collection<Schedule>();

        public Restaurant() { }

        public Restaurant(CreateRestaurantRequest request, AdressRequest addressRequest, InformationRequest informationRequest, LoginRequest loginRequest, PaymentRequest paymentRequest)
        {
            Name = request.Name;
            Cnpj = request.Cnpj;
            Address = new Address(addressRequest);
            Information = new Information(informationRequest);
            Login = new Login(loginRequest);
            Payments = new Payments(paymentRequest);
        }

        public void Update(UpdateRestaurantRequest request) => Name = request.Name ?? Name;
    }
}
