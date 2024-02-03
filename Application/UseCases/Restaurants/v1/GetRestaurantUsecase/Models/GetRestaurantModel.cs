using Application.Shared.Entities;

namespace Application.UseCases.Restaurants.v1.GetRestaurantUsecase.Models
{
    public class GetRestaurantModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long CNPJ { get; set; }
        public Information? Information { get; set; }
        public Payments Payments { get; set; }
        public Adress Adress { get; set; }
        public List<OpeningHours>? ServiceHours { get; set; }

        public GetRestaurantModel(Restaurant restaurant)
        {
            Id = restaurant.Id;
            Name = restaurant.Name;
            CNPJ = restaurant.CNPJ;
            Information = restaurant.Information;
            Payments = restaurant.Payments;
            Adress = restaurant.Adress;
            ServiceHours = restaurant.ServiceHours;
        }
    }
}
