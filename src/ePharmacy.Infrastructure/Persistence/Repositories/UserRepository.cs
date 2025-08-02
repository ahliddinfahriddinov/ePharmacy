using ePharmacy.Application.RepositoryInterfaces;
using ePharmacy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ePharmacy.Infrastructure.Persistence.Repositories;
public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<long> InsertAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user.UserId;
    }

    public async Task RemoveAsync(long id)
    {
        var user = await SelectByIdAsync(id);
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<User>> SelectAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> SelectByIdAsync(long id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
        if (user == null)
        {
            throw new KeyNotFoundException($"User with ID {id} not found.");
        }
        return user;
    }

    public async Task<User> SelectByEmailAsync(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null)
        {
            throw new KeyNotFoundException($"User with email {email} not found.");
        }
        return user;
    }

    public async Task<User> SelectByPhoneNumberAsync(string phoneNumber)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
        if (user == null)
        {
            throw new KeyNotFoundException($"User with phone number {phoneNumber} not found.");
        }
        return user;
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}
