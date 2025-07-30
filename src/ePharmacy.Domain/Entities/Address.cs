namespace ePharmacy.Domain.Entities;

public class Address : BaseEntity
{
    public long AddressId { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public Pharmacy Pharmacy { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
