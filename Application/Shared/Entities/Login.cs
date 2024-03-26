using Application.Shared.Models.Request;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Application.Shared.Entities
{
    public class Login
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Access { get; set; } = null!;
        public string Password { get; set; } = null!;

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public Login() { }

        public Login(LoginRequest request)
        {
            Password = request.Password;
            Access = request.Access;
        }

        internal void Update(LoginRequest request)
        {
            Access = request.Access ?? Access;
            Password = request.Password ?? Password;
        }
    }
}
