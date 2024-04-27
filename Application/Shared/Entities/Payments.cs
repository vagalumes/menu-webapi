using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Application.Shared.Enum;
using Application.Shared.Models.Request;

namespace Application.Shared.Entities;

public class Payments
{
    public Payments(PaymentRequest request)
    {
        TypePayment = request.TypePayments;
    }

    public Payments(PaymentRequest? request, Payments payments)
    {
        TypePayment = request!.TypePayments;
    }

    public Payments()
    {
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public List<EnumTypePayments> TypePayment { get; set; } = null!;

    public Restaurant Restaurant { get; set; } = null!;

    internal void Update(PaymentRequest payments)
    {
        TypePayment = payments.TypePayments;
    }
}