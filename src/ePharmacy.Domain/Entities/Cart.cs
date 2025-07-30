namespace ePharmacy.Domain.Entities;
public class Cart : BaseEntity
{
    public long CartId { get; set; }
    public decimal TotalAmount { get; set; }
    public bool IsActive { get; set; } = true;

    public long UserId { get; set; }
    public User User { get; set; }

    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}
