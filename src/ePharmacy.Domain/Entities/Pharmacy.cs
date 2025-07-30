namespace ePharmacy.Domain.Entities;
public class Pharmacy : BaseEntity
{
    public long PharmacyId { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public TimeSpan OpeningTime { get; set; }
    public TimeSpan ClosingTime { get; set; }
    public bool IsActive { get; set; } = true;
    public double Rating { get; set; }
    public int ReviewCount { get; set; }

    public long AddressId { get; set; }
    public Address Address { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }

    public ICollection<PharmacyDrug> PharmacyDrugs { get; set; } = new List<PharmacyDrug>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}
