namespace ePharmacy.Application.Dtos.PaymentDtos;
public class CreatePaymentDto
{
    public decimal Amount { get; set; }
    public long OrderId { get; set; }
}
