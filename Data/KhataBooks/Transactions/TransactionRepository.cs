using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Transactions;

public class TransactionRepository:ITransactionRepository
{
    private readonly DataContext _context;

    public TransactionRepository(DataContext context)
    {   
        _context = context;
    }
    public async Task Delete(int id)    
    {
        var transaction = await _context.Transactions.FindAsync(id);
        _context.Transactions.Remove(transaction);
        await _context.SaveChangesAsync();  
    }
    public async Task<List<Transaction>> GetAll()
    {
        var transaction = await _context.Transactions.ToListAsync();
        return transaction;
    }

    public async Task<Transaction> GetById(int id)
    {
        return await _context.Transactions.FindAsync(id);
    }
    public async Task<Transaction> Create(Transaction transaction)
    {
        await _context.Transactions.AddAsync(transaction);
        await _context.SaveChangesAsync();

        return transaction;
    }

    public async Task Update(Transaction transaction)
    {
        _context.Transactions.Update(transaction);
        await _context.SaveChangesAsync();
    }
}