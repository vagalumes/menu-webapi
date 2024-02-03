using Application.Shared.Enum;
using Application.Shared.Models.Request;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Application.Shared.Entities
{
    public class Payments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public List<EnumTypePayments> TypePayment { get; set; } = null!;

        [JsonIgnore]
        public Guid RestaurantId { get; set; }
        [JsonIgnore]
        public Restaurant Restaurant { get; set; } = null!;

        public Payments(PaymentRequest request) => TypePayment = request.TypePayments;

        public Payments(PaymentRequest? request, Payments payments) => TypePayment = request!.TypePayments ?? payments.TypePayment;

        public Payments() { }

        internal void Update(PaymentRequest payments)
        {
            TypePayment = payments.TypePayments != null ? payments.TypePayments.ToList() : TypePayment;
        }
    }
}
