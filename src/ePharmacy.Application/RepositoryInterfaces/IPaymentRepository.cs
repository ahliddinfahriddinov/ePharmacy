using ePharmacy.Domain.Entities;

namespace ePharmacy.Application.RepositoryInterfaces;
public interface IPaymentRepository
{
    Task<Payment> SelectByIdAsync(long id);
    Task<ICollection<Payment>> SelectAllAsync();
    Task<long> InsertAsync(Payment payment);
    Task<Payment> SelectByOrderIdAsync(long orderId);
    Task UpdateAsync(Payment payment);
    Task RemoveAsync(long id);
}

