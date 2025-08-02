using ePharmacy.Application.RepositoryInterfaces;
using ePharmacy.Domain.Entities;
using ePharmacy.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ePharmacy.Infrastructure.Persistence.Repositories;
public class DrugRepository : IDrugRepository
{
    private readonly AppDbContext _context;

    public DrugRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<long> InsertAsync(Drug drug)
    {
        _context.Drugs.Add(drug);
        await _context.SaveChangesAsync();
        return drug.DrugId;
    }

    public async Task RemoveAsync(long id)
    {
        var drug = await SelectByIdAsync(id);
        _context.Drugs.Remove(drug);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Drug>> SelectAllAsync()
    {
        return await _context.Drugs.ToListAsync();
    }

    public async Task<Drug> SelectByIdAsync(long id)
    {
        var drug = await _context.Drugs.FirstOrDefaultAsync(d => d.DrugId == id);
        if (drug == null)
        {
            throw new KeyNotFoundException($"Drug with ID {id} not found.");
        }
        return drug;
    }

    public async Task<ICollection<Drug>> SelectByCategoryAsync(DrugCategory category)
    {
        return await _context.Drugs
            .Where(d => d.Category == category)
            .ToListAsync();
    }

    public async Task<Drug?> SelectByBarcodeAsync(string barcode)
    {
        return await _context.Drugs
            .FirstOrDefaultAsync(d => d.Barcode == barcode);
    }

    public async Task<ICollection<Drug>> SearchByNameAsync(string name)
    {
        return await _context.Drugs
            .Where(d => d.Name.ToLower().Contains(name.ToLower()))
            .ToListAsync();
    }

    public async Task UpdateAsync(Drug drug)
    {
        _context.Drugs.Update(drug);
        await _context.SaveChangesAsync();
    }
}