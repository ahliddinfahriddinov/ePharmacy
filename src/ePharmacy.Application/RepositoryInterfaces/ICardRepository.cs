using ePharmacy.Domain.Entities;
using ePharmacy.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePharmacy.Application.RepositoryInterfaces;
public interface ICardRepository
{
    Task<Card> SelectByIdAsync(long id);
    Task<ICollection<Card>> SelectAllAsync();
    Task<long> InsertAsync(Card card);
    Task<ICollection<Card>> SelectByUserIdAsync(long userId);
    Task<ICollection<Card>> SelectByCardTypeAsync(CardType cardType);
    Task<ICollection<Card>> SelectActiveCardsAsync();
    Task<ICollection<Card>> SelectActiveCardsByUserIdAsync(long userId);
    Task<Card> SelectDefaultCardByUserIdAsync(long userId);
    Task UpdateAsync(Card card);
    Task RemoveAsync(long id);
}
