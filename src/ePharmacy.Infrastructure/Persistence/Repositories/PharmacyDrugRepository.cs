using ePharmacy.Application.RepositoryInterfaces;
using ePharmacy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ePharmacy.Infrastructure.Persistence.Repositories;
public class PharmacyDrugRepository : IPharmacyDrugRepository
{
    private readonly AppDbContext _context;

    public PharmacyDrugRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<long> InsertAsync(PharmacyDrug pharmacyDrug)
    {
        _context.PharmacyDrugs.Add(pharmacyDrug);
        await _context.SaveChangesAsync();
        return pharmacyDrug.PharmacyDrugId;
    }

    public async Task RemoveAsync(long id)
    {
        var pharmacyDrug = await SelectByIdAsync(id);
        _context.PharmacyDrugs.Remove(pharmacyDrug);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<PharmacyDrug>> SelectAllAsync()
    {
        return await _context.PharmacyDrugs.ToListAsync();
    }

    public async Task<PharmacyDrug> SelectByIdAsync(long id)
    {
        var pharmacyDrug = await _context.PharmacyDrugs.FirstOrDefaultAsync(pd => pd.PharmacyDrugId == id);
        if (pharmacyDrug == null)
        {
            throw new KeyNotFoundException($"PharmacyDrug with ID {id} not found.");
        }
        return pharmacyDrug;
    }

    public async Task<ICollection<PharmacyDrug>> SelectByPharmacyIdAsync(long pharmacyId)
    {
        return await _context.PharmacyDrugs
            .Where(pd => pd.PharmacyId == pharmacyId)
            .ToListAsync();
    }

    public async Task<ICollection<PharmacyDrug>> SelectByDrugIdAsync(long drugId)
    {
        return await _context.PharmacyDrugs
            .Where(pd => pd.DrugId == drugId)
            .ToListAsync();
    }

    public async Task<PharmacyDrug> SelectByPharmacyAndDrugAsync(long pharmacyId, long drugId)
    {
        var pharmacyDrug = await _context.PharmacyDrugs
            .FirstOrDefaultAsync(pd => pd.PharmacyId == pharmacyId && pd.DrugId == drugId);
        if (pharmacyDrug == null)
        {
            throw new KeyNotFoundException($"PharmacyDrug for Pharmacy {pharmacyId} and Drug {drugId} not found.");
        }
        return pharmacyDrug;
    }

    public async Task<ICollection<PharmacyDrug>> SelectAvailableDrugsAsync(long pharmacyId)
    {
        return await _context.PharmacyDrugs
            .Where(pd => pd.PharmacyId == pharmacyId && pd.IsAvailable == true && pd.StockQuantity > 0)
            .ToListAsync();
    }

    public async Task UpdateAsync(PharmacyDrug pharmacyDrug)
    {
        _context.PharmacyDrugs.Update(pharmacyDrug);
        await _context.SaveChangesAsync();
    }
}
