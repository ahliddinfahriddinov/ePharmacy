using ePharmacy.Application.RepositoryInterfaces;
using ePharmacy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ePharmacy.Infrastructure.Persistence.Repositories;
public class PharmacyRepository : IPharmacyRepository
{
    private readonly AppDbContext _context;

    public PharmacyRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<long> InsertAsync(Pharmacy pharmacy)
    {
        _context.Pharmacies.Add(pharmacy);
        await _context.SaveChangesAsync();
        return pharmacy.PharmacyId;
    }

    public async Task RemoveAsync(long id)
    {
        var pharmacy = await SelectByIdAsync(id);
        _context.Pharmacies.Remove(pharmacy);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Pharmacy>> SelectAllAsync()
    {
        return await _context.Pharmacies.ToListAsync();
    }

    public async Task<Pharmacy> SelectByIdAsync(long id)
    {
        var pharmacy = await _context.Pharmacies.FirstOrDefaultAsync(p => p.PharmacyId == id);
        if (pharmacy == null)
        {
            throw new KeyNotFoundException($"Pharmacy with ID {id} not found.");
        }
        return pharmacy;
    }

    public async Task<ICollection<Pharmacy>> SelectByCityAsync(string city)
    {
        return await _context.Pharmacies
            .Include(p => p.Address)
            .Where(p => p.Address.City.ToLower().Contains(city.ToLower()) && p.IsActive == true)
            .ToListAsync();
    }

    public async Task UpdateAsync(Pharmacy pharmacy)
    {
        _context.Pharmacies.Update(pharmacy);
        await _context.SaveChangesAsync();
    }
}