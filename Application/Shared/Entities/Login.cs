using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Application.Shared.Models.Request;

namespace Application.Shared.Entities;

public class Login
{
    public Login()
    {
    }

    public Login(LoginRequest request)
    {
        Password = request.Password;
        Access = request.Access;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string Access { get; set; } = null!;
    public string Password { get; set; } = null!;

    public Guid UserId { get; set; }
    public User? User { get; set; }

    internal void Update(LoginRequest request)
    {
        Access = request.Access;
        Password = request.Password;
    }
}