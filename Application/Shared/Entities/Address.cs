using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Shared.Entities
{
    public class Address()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? Street { get; set; }
        public string? Neighborhood { get; set; }
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string? Complement { get; set; }
        public string ZipCode { get; set; } = string.Empty;
        public string? Number { get; set; }

        public Guid RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } = null!;
    }
}
