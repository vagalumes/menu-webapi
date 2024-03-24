using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Shared.Entities
{
    public class Image()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Path { get; set; } = null!;
        public string Extension { get; set; } = string.Empty;

        public Guid? RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }

        public Guid? UserId { get; set; }
        public User? User { get; set; }
    }
}
