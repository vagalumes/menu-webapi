using Application.Shared.Models.Request;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Application.Shared.Entities
{
    public class Adress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? Road { get; set; }
        public string? Neighborhood { get; set; }
        public string? City { get; set; }
        public string? Uf { get; set; }
        public string? Complement { get; set; }
        public long Cep { get; set; }
        public int Number { get; set; }

        [JsonIgnore]
        public Guid? UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }

        [JsonIgnore]
        public Guid? RestaurantId { get; set; }
        [JsonIgnore]
        public Restaurant? Restaurant { get; set; }

        public Adress() { }

        public Adress(AdressRequest request)
        {
            Road = request.Road;
            Neighborhood = request.Neighborhood;
            City = request.City;
            Uf = request.Uf;
            Complement = request.Complement;
            Cep = request.Cep;
            Number = request.Number;
        }

        public void Update(AdressRequest request)
        {
            Road = request.Road ?? Road;
            Neighborhood = request.Neighborhood ?? Neighborhood;
            City = request.City ?? City;
            Uf = request.Uf ?? Uf;
            Complement = request.Complement ?? Complement;
            Cep = request.Cep != 0 ? request.Cep : Cep;
            Number = request.Number != 0 ? request.Number : Number;
        }
    }
}
