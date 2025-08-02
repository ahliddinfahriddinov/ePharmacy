namespace ePharmacy.Application.Dtos.AddressDtos;
public class CreateAddressDto
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public long UserId { get; set; }
}
