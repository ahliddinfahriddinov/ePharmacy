using ePharmacy.Domain.Entities;

namespace ePharmacy.Application.RepositoryInterfaces;
public interface IOrderRepository
{
    Task<Order> SelectByIdAsync(long id);
    Task<ICollection<Order>> SelectAllAsync();
    Task<long> InsertAsync(Order order);
    Task<ICollection<Order>> SelectByUserIdAsync(long userId);
    Task<ICollection<Order>> SelectByPharmacyIdAsync(long pharmacyId);
    Task UpdateAsync(Order order);
    Task RemoveAsync(long id);
}