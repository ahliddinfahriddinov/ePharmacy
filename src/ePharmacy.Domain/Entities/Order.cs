using ePharmacy.Domain.Enums;

namespace ePharmacy.Domain.Entities;
public class Order : BaseEntity
{
    public long OrderId { get; set; }
    public string OrderNumber { get; set; }
    public OrderStatus Status { get; set; }
    public decimal TotalAmount { get; set; }
    public string Notes { get; set; }
    public DateTime? DeliveredAt { get; set; }
    public string PrescriptionImageUrl { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }

    public long PharmacyId { get; set; }
    public Pharmacy Pharmacy { get; set; }

    public long AddressId { get; set; }
    public Address Address { get; set; }

    public long PaymentId { get; set; }
    public Payment Payment { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; }
}
