using AutoMapper;
using ePharmacy.Application.Dtos.CardDtos;
using ePharmacy.Application.RepositoryInterfaces;
using ePharmacy.Domain.Entities;
using ePharmacy.Domain.Enums;
using FluentValidation;

namespace ePharmacy.Application.Services.CardService;
public class CardService : ICardService
{
    private readonly ICardRepository _cardRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateCardDto> _createValidator;

    public CardService(
        ICardRepository cardRepository,
        IMapper mapper,
        IValidator<CreateCardDto> createValidator)
    {
        _cardRepository = cardRepository;
        _mapper = mapper;
        _createValidator = createValidator;
    }


    public async Task<CardDto> GetCardByIdAsync(long id)
    {
        var card = await _cardRepository.SelectByIdAsync(id);
        return _mapper.Map<CardDto>(card);
    }

    public async Task<ICollection<CardDto>> GetAllCardsAsync()
    {
        var cards = await _cardRepository.SelectAllAsync();
        return _mapper.Map<ICollection<CardDto>>(cards);
    }

    public async Task<ICollection<CardDto>> GetCardsByUserIdAsync(long userId)
    {
        var cards = await _cardRepository.SelectByUserIdAsync(userId);
        return _mapper.Map<ICollection<CardDto>>(cards);
    }

    public async Task<ICollection<CardDto>> GetCardsByTypeAsync(CardType cardType)
    {
        var cards = await _cardRepository.SelectByCardTypeAsync(cardType);
        return _mapper.Map<ICollection<CardDto>>(cards);
    }

    public async Task<ICollection<CardDto>> GetActiveCardsAsync()
    {
        var cards = await _cardRepository.SelectActiveCardsAsync();
        return _mapper.Map<ICollection<CardDto>>(cards);
    }

    public async Task<ICollection<CardDto>> GetActiveCardsByUserIdAsync(long userId)
    {
        var cards = await _cardRepository.SelectActiveCardsByUserIdAsync(userId);
        return _mapper.Map<ICollection<CardDto>>(cards);
    }

    public async Task<CardDto> GetDefaultCardByUserIdAsync(long userId)
    {
        var card = await _cardRepository.SelectDefaultCardByUserIdAsync(userId);
        return _mapper.Map<CardDto>(card);
    }



    public async Task DeleteCardAsync(long id)
    {
        await _cardRepository.RemoveAsync(id);
    }

    public async Task<long> CreateCardAsync(CreateCardDto createCardDto)
    {
        var validationResult = await _createValidator.ValidateAsync(createCardDto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }


        var card = _mapper.Map<Card>(createCardDto);
        await _cardRepository.InsertAsync(card);
        return card.CardId;
    }

    public async Task UpdateCardAsync(long id, CardDto cardDto)
    {
        var existingCard = await _cardRepository.SelectByIdAsync(id);

        if (cardDto.IsDefault && !existingCard.IsDefault)
        {
            var currentDefaultCard = await _cardRepository.SelectDefaultCardByUserIdAsync(cardDto.UserId);
            if (currentDefaultCard != null)
            {
                currentDefaultCard.IsDefault = false;
                await _cardRepository.UpdateAsync(currentDefaultCard);
            }
        }
        _mapper.Map(cardDto, existingCard);
        await _cardRepository.UpdateAsync(existingCard);
    }
}
