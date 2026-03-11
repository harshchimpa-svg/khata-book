using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.PaymentLogs;

public class PaymentLogRepository:IPaymentLogRepository
{
    private readonly DataContext _context;

    public PaymentLogRepository(DataContext context)
    {   
        _context = context;
    }

    public async Task<List<Transaction>> GetAll()
    {
        return await _context.Transactions
            .Include(t => t.Customer) 
            .ToListAsync();  
    }
}