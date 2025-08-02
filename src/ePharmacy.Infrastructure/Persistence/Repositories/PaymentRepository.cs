using ePharmacy.Application.RepositoryInterfaces;
using ePharmacy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ePharmacy.Infrastructure.Persistence.Repositories;
public class PaymentRepository : IPaymentRepository
{
    private readonly AppDbContext _context;

    public PaymentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<long> InsertAsync(Payment payment)
    {
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();
        return payment.PaymentId;
    }

    public async Task RemoveAsync(long id)
    {
        var payment = await SelectByIdAsync(id);
        _context.Payments.Remove(payment);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Payment>> SelectAllAsync()
    {
        return await _context.Payments.ToListAsync();
    }

    public async Task<Payment> SelectByIdAsync(long id)
    {
        var payment = await _context.Payments.FirstOrDefaultAsync(p => p.PaymentId == id);
        if (payment == null)
        {
            throw new KeyNotFoundException($"Payment with ID {id} not found.");
        }
        return payment;
    }

    public async Task<Payment> SelectByOrderIdAsync(long orderId)
    {
        var payment = await _context.Payments.FirstOrDefaultAsync(p => p.OrderId == orderId);
        if (payment == null)
        {
            throw new KeyNotFoundException($"Payment for Order with ID {orderId} not found.");
        }
        return payment;
    }

    public async Task UpdateAsync(Payment payment)
    {
        _context.Payments.Update(payment);
        await _context.SaveChangesAsync();
    }
}
