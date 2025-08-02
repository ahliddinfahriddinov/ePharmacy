using ePharmacy.Domain.Entities;

namespace ePharmacy.Application.RepositoryInterfaces;
public interface IAddressRepository
{
    Task<Address> SelectByIdAsync(long id);
    Task<ICollection<Address>> SelectAllAsync();
    Task<long> InsertAsync(Address address);
    Task<ICollection<Address>> SelectByUserIdAsync(long userId);
    Task<ICollection<Address>> SelectByCityAsync(string city);
    Task<ICollection<Address>> SelectByStateAsync(string state);
    Task<ICollection<Address>> SelectByCountryAsync(string country);
    Task<Address> SelectWithOrdersAsync(long id);
    Task<Address> SelectWithPharmacyAsync(long id);
    Task<Address> SelectWithUserAsync(long id);
    Task UpdateAsync(Address address);
    Task RemoveAsync(long id);
}