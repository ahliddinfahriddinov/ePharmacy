using ePharmacy.Application.RepositoryInterfaces;
using ePharmacy.Domain.Entities;
using ePharmacy.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ePharmacy.Infrastructure.Persistence.Repositories;
public class CardRepository : ICardRepository
{
    private readonly AppDbContext _context;

    public CardRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<long> InsertAsync(Card card)
    {
        _context.Cards.Add(card);
        await _context.SaveChangesAsync();
        return card.CardId;
    }

    public async Task RemoveAsync(long id)
    {
        var card = await SelectByIdAsync(id);
        _context.Cards.Remove(card);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Card>> SelectAllAsync()
    {
        return await _context.Cards.ToListAsync();
    }

    public async Task<Card> SelectByIdAsync(long id)
    {
        var card = await _context.Cards.FirstOrDefaultAsync(c => c.CardId == id);
        if (card == null)
        {
            throw new KeyNotFoundException($"Card with ID {id} not found.");
        }
        return card;
    }

    public async Task<ICollection<Card>> SelectByUserIdAsync(long userId)
    {
        return await _context.Cards
            .Where(c => c.UserId == userId)
            .ToListAsync();
    }

    public async Task<ICollection<Card>> SelectByCardTypeAsync(CardType cardType)
    {
        return await _context.Cards
            .Where(c => c.CardType == cardType)
            .ToListAsync();
    }

    public async Task<ICollection<Card>> SelectActiveCardsAsync()
    {
        return await _context.Cards
            .Where(c => c.IsActive == true)
            .ToListAsync();
    }

    public async Task<ICollection<Card>> SelectActiveCardsByUserIdAsync(long userId)
    {
        return await _context.Cards
            .Where(c => c.UserId == userId && c.IsActive == true)
            .ToListAsync();
    }

    public async Task<Card> SelectDefaultCardByUserIdAsync(long userId)
    {
        var card = await _context.Cards
            .FirstOrDefaultAsync(c => c.UserId == userId && c.IsDefault == true && c.IsActive == true);
        if (card == null)
        {
            throw new KeyNotFoundException($"Default card for User with ID {userId} not found.");
        }
        return card;
    }

    public async Task UpdateAsync(Card card)
    {
        _context.Cards.Update(card);
        await _context.SaveChangesAsync();
    }
}
