using ePharmacy.Domain.Enums;

namespace ePharmacy.Application.Dtos.OrderDtos;
public class OrderDto
{
    public long OrderId { get; set; }
    public string OrderNumber { get; set; }
    public OrderStatus Status { get; set; }
    public decimal TotalAmount { get; set; }
    public string Notes { get; set; }
    public DateTime? DeliveredAt { get; set; }
    public string PrescriptionImageUrl { get; set; }
    public long UserId { get; set; }
    public long PharmacyId { get; set; }
    public long AddressId { get; set; }
    public long PaymentId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
