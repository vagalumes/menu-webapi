using Application.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Shared.Entities
{
    public class RestaurantsImages : Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } = null!;
    }
}
