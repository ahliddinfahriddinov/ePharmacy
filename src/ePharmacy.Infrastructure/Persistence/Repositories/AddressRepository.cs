using ePharmacy.Application.RepositoryInterfaces;
using ePharmacy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ePharmacy.Infrastructure.Persistence.Repositories;
public class AddressRepository : IAddressRepository
{
    private readonly AppDbContext _context;

    public AddressRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<long> InsertAsync(Address address)
    {
        _context.Addresses.Add(address);
        await _context.SaveChangesAsync();
        return address.AddressId;
    }

    public async Task RemoveAsync(long id)
    {
        var address = await SelectByIdAsync(id);
        _context.Addresses.Remove(address);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Address>> SelectAllAsync()
    {
        return await _context.Addresses.ToListAsync();
    }

    public async Task<Address> SelectByIdAsync(long id)
    {
        var address = await _context.Addresses.FirstOrDefaultAsync(a => a.AddressId == id);
        if (address == null)
        {
            throw new KeyNotFoundException($"Address with ID {id} not found.");
        }
        return address;
    }

    public async Task<ICollection<Address>> SelectByUserIdAsync(long userId)
    {
        return await _context.Addresses
            .Where(a => a.UserId == userId)
            .ToListAsync();
    }

    public async Task<ICollection<Address>> SelectByCityAsync(string city)
    {
        return await _context.Addresses
            .Where(a => a.City.ToLower().Contains(city.ToLower()))
            .ToListAsync();
    }

    public async Task<ICollection<Address>> SelectByStateAsync(string state)
    {
        return await _context.Addresses
            .Where(a => a.State.ToLower().Contains(state.ToLower()))
            .ToListAsync();
    }

    public async Task<ICollection<Address>> SelectByCountryAsync(string country)
    {
        return await _context.Addresses
            .Where(a => a.Country.ToLower().Contains(country.ToLower()))
            .ToListAsync();
    }

    public async Task<Address> SelectWithOrdersAsync(long id)
    {
        var address = await _context.Addresses
            .Include(a => a.Orders)
            .FirstOrDefaultAsync(a => a.AddressId == id);
        if (address == null)
        {
            throw new KeyNotFoundException($"Address with ID {id} not found.");
        }
        return address;
    }

    public async Task<Address> SelectWithPharmacyAsync(long id)
    {
        var address = await _context.Addresses
            .Include(a => a.Pharmacy)
            .FirstOrDefaultAsync(a => a.AddressId == id);
        if (address == null)
        {
            throw new KeyNotFoundException($"Address with ID {id} not found.");
        }
        return address;
    }

    public async Task<Address> SelectWithUserAsync(long id)
    {
        var address = await _context.Addresses
            .Include(a => a.User)
            .FirstOrDefaultAsync(a => a.AddressId == id);
        if (address == null)
        {
            throw new KeyNotFoundException($"Address with ID {id} not found.");
        }
        return address;
    }

    public async Task UpdateAsync(Address address)
    {
        _context.Addresses.Update(address);
        await _context.SaveChangesAsync();
    }
}
