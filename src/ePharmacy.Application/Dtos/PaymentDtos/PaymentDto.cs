using ePharmacy.Domain.Enums;

namespace ePharmacy.Application.Dtos.PaymentDtos;
public class PaymentDto
{
    public long PaymentId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentStatus Status { get; set; }
    public string Transaction { get; set; }
    public long OrderId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}