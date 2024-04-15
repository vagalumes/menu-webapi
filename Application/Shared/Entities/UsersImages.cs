using Application.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Shared.Entities
{
    public class UsersImages : Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
