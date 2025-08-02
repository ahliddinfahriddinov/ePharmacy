using ePharmacy.Domain.Enums;

namespace ePharmacy.Application.Dtos.CardDtos;
public class CreateCardDto
{
    public string CardHolderName { get; set; }
    public string CardNumber { get; set; }
    public string ExpiryMonth { get; set; }
    public string ExpiryYear { get; set; }
    public string? CVV { get; set; }
    public CardType CardType { get; set; }
    public bool IsDefault { get; set; } = false;
    public long UserId { get; set; }
}

