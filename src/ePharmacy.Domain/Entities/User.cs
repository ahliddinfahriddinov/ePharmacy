using ePharmacy.Domain.Enums;

namespace ePharmacy.Domain.Entities;
public class User : BaseEntity
{
    public long UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string PasswordHash { get; set; }
    public UserRole Role { get; set; }

    public ICollection<Address> Addresses { get; set; }
    public ICollection<Order> Orders { get; set; }
    public ICollection<Card> Cards { get; set; }
    public ICollection<RefreshToken> RefreshTokens { get; set; }
    public Pharmacy? Pharmacy { get; set; }
    public Cart? Cart { get; set; }
}
