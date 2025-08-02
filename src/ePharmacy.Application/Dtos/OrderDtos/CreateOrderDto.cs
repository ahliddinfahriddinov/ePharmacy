namespace ePharmacy.Application.Dtos.OrderDtos;
public class CreatePaymentDto
{
    public decimal TotalAmount { get; set; }
    public string Notes { get; set; }
    public string PrescriptionImageUrl { get; set; }
    public long UserId { get; set; }
    public long PharmacyId { get; set; }
    public long AddressId { get; set; }
    public long PaymentId { get; set; }
}
