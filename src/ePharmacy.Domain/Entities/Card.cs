using ePharmacy.Domain.Enums;

namespace ePharmacy.Domain.Entities;
public class Card : BaseEntity
{
    public long CardId { get; set; }
    public string CardHolderName { get; set; }
    public string CardNumber { get; set; }
    public string ExpiryMonth { get; set; }
    public string ExpiryYear { get; set; }
    public string CVV { get; set; }
    public CardType CardType { get; set; }
    public bool IsDefault { get; set; } = false;
    public bool IsActive { get; set; } = true;

    public long UserId { get; set; }
    public User User { get; set; }
}