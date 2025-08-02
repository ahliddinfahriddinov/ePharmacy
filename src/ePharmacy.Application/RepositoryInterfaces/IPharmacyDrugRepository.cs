using ePharmacy.Domain.Entities;

namespace ePharmacy.Application.RepositoryInterfaces;
public interface IPharmacyDrugRepository
{
    Task<PharmacyDrug> SelectByIdAsync(long id);
    Task<ICollection<PharmacyDrug>> SelectAllAsync();
    Task<long> InsertAsync(PharmacyDrug pharmacyDrug);
    Task<ICollection<PharmacyDrug>> SelectByPharmacyIdAsync(long pharmacyId);
    Task<ICollection<PharmacyDrug>> SelectByDrugIdAsync(long drugId);
    Task<PharmacyDrug> SelectByPharmacyAndDrugAsync(long pharmacyId, long drugId);
    Task<ICollection<PharmacyDrug>> SelectAvailableDrugsAsync(long pharmacyId);
    Task UpdateAsync(PharmacyDrug pharmacyDrug);
    Task RemoveAsync(long id);
}
