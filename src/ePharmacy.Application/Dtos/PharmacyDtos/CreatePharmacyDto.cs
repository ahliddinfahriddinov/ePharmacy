namespace ePharmacy.Application.Dtos.PharmacyDtos;
public class CreatePharmacyDto
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public TimeSpan OpeningTime { get; set; }
    public TimeSpan ClosingTime { get; set; }
    public long AddressId { get; set; }
    public long UserId { get; set; }
}