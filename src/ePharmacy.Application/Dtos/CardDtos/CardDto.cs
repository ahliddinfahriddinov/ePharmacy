using ePharmacy.Domain.Enums;

namespace ePharmacy.Application.Dtos.CardDtos;
public class CardDto
{
    public long CardId { get; set; }
    public string CardHolderName { get; set; }
    public string CardNumber { get; set; }
    public string ExpiryMonth { get; set; }
    public string ExpiryYear { get; set; }
    public CardType CardType { get; set; }
    public bool IsDefault { get; set; }
    public bool IsActive { get; set; }
    public long UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
