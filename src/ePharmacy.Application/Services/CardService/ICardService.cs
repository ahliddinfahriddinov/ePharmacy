using ePharmacy.Application.Dtos.CardDtos;
using ePharmacy.Domain.Enums;

namespace ePharmacy.Application.Services.CardService;

public interface ICardService
{
    Task<CardDto> GetCardByIdAsync(long id);
    Task<ICollection<CardDto>> GetAllCardsAsync();
    Task<ICollection<CardDto>> GetCardsByUserIdAsync(long userId);
    Task<ICollection<CardDto>> GetCardsByTypeAsync(CardType cardType);
    Task<ICollection<CardDto>> GetActiveCardsAsync();
    Task<ICollection<CardDto>> GetActiveCardsByUserIdAsync(long userId);
    Task<CardDto> GetDefaultCardByUserIdAsync(long userId);
    Task<long> CreateCardAsync(CreateCardDto createCardDto);
    Task UpdateCardAsync(long id, CardDto cardDto);
    Task DeleteCardAsync(long id);
}
