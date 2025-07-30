using ePharmacy.Domain.Enums;

namespace ePharmacy.Domain.Entities;

public class Payment : BaseEntity
{
    public long PaymentId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentStatus Status { get; set; }
    public string Transaction { get; set; }

    public long OrderId { get; set; }
    public Order Order { get; set; }
}
