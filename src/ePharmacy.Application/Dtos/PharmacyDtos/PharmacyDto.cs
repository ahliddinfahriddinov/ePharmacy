namespace ePharmacy.Application.Dtos.PharmacyDtos;
public class PharmacyDto
{
    public long PharmacyId { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public TimeSpan OpeningTime { get; set; }
    public TimeSpan ClosingTime { get; set; }
    public bool IsActive { get; set; }
    public double Rating { get; set; }
    public int ReviewCount { get; set; }
    public long AddressId { get; set; }
    public long UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
