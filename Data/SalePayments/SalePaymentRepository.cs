using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.SalePayments;

public class SalePaymentRepository:ISalePaymentRepository
{
    private readonly DataContext _context;

    public SalePaymentRepository(DataContext context)
    {   
        _context = context;
    }

    public async Task Delete(int id)    
    {
        var salePayment = await _context.SalePayments.FindAsync(id);
        _context.SalePayments.Remove(salePayment);
        await _context.SaveChangesAsync();   
    }
    public async Task<List<SalePayment>> GetAll()
    {
        var salePayment = await _context.SalePayments.ToListAsync();
        return salePayment;
    }

    public async Task<SalePayment> GetById(int id)
    {
        return await _context.SalePayments.FindAsync(id);
    }
    public async Task<SalePayment> Create(SalePayment salePayment)
    {
        await _context.SalePayments.AddAsync(salePayment);
        await _context.SaveChangesAsync();

        return salePayment;
    }

    public async Task Update(SalePayment salePayment)
    {
        _context.SalePayments.Update(salePayment);
        await _context.SaveChangesAsync();
    }
}