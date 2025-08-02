using ePharmacy.Domain.Entities;

namespace ePharmacy.Application.RepositoryInterfaces;
public interface IPharmacyRepository
{
    Task<Pharmacy> SelectByIdAsync(long id);
    Task<ICollection<Pharmacy>> SelectAllAsync();
    Task<long> InsertAsync(Pharmacy pharmacy);
    Task<ICollection<Pharmacy>> SelectByCityAsync(string city);
    Task UpdateAsync(Pharmacy pharmacy);
    Task RemoveAsync(long id);
}
