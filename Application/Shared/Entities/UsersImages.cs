using Application.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Shared.Entities
{
    public class UsersImages : IImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public string Extension { get; set; } = string.Empty;

        public string FullNamePath { get; set; } = string.Empty;

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
