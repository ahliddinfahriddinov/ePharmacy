using ePharmacy.Domain.Entities;

namespace ePharmacy.Application.RepositoryInterfaces;
public interface IUserRepository
{
    Task<User> SelectByIdAsync(long id);
    Task<ICollection<User>> SelectAllAsync();
    Task<long> InsertAsync(User user);
    Task<User> SelectByEmailAsync(string email);
    Task<User> SelectByPhoneNumberAsync(string phoneNumber);
    Task<bool> EmailExistsAsync(string email);
    Task UpdateAsync(User user);
    Task RemoveAsync(long id);
    Task<int> SaveChangesAsync();
}
