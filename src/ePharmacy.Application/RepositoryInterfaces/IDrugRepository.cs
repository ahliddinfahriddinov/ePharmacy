using ePharmacy.Domain.Entities;
using ePharmacy.Domain.Enums;

namespace ePharmacy.Application.RepositoryInterfaces;
public interface IDrugRepository
{
    Task<Drug> SelectByIdAsync(long id);
    Task<ICollection<Drug>> SelectAllAsync();
    Task<long> InsertAsync(Drug drug);
    Task<ICollection<Drug>> SelectByCategoryAsync(DrugCategory category);
    Task<ICollection<Drug>> SearchByNameAsync(string name);
    Task<Drug?> SelectByBarcodeAsync(string barcode);
    Task UpdateAsync(Drug drug);
    Task RemoveAsync(long id);
}