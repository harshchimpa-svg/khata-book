using Application.Transactions.Dto;
using Data;
using Domain;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Application.Transactions;

public class TransactionApplication : ITransactionApplication
{
    private readonly DataContext _datacontext;

    public TransactionApplication(DataContext datacontext)
    {
        _datacontext = datacontext;
    }

    public async Task<string> Create(CreateTransactionDto dto)
    {
        var customer = await _datacontext.Customers.FindAsync(dto.CustomerId);

        var transaction = new Transaction();
        transaction.CustomerId = dto.CustomerId;
        transaction.TransactionType = dto.TransactionType;
        transaction.Amount = dto.Amount;

        await _datacontext.Transactions.AddAsync(transaction);

        if (dto.TransactionType == TransactionType.Credit)
            customer.Balance += dto.Amount;
        else
            customer.Balance -= dto.Amount;

        var paymentLog = new PaymentLog();
        paymentLog.CustomerId = dto.Customer.Id;
        paymentLog.Amount = dto.Amount;
        paymentLog.TransactionType = dto.TransactionType;

        await _datacontext.PaymentLogs.AddAsync(paymentLog);

        await _datacontext.SaveChangesAsync();

        return "Transaction created successfully";
    }

    public async Task Delete(int id)
    {
        var transaction = await _datacontext.Transactions.FindAsync(id);
        var customer = await _datacontext.Customers.FindAsync(transaction.CustomerId);

        if (transaction.TransactionType == TransactionType.Credit)
            customer.Balance -= transaction.Amount;
        else
            customer.Balance += transaction.Amount;

        _datacontext.Transactions.Remove(transaction);

        await _datacontext.SaveChangesAsync();
    }

    public async Task<List<TransactionDto>> GetAll()
    {
        var transactions = await _datacontext.Transactions.ToListAsync();
        var list = new List<TransactionDto>();

        foreach (var t in transactions)
        {
            var dto = new TransactionDto();
            dto.Id = t.Id;
            dto.CustomerId = t.CustomerId;
            dto.TransactionType = t.TransactionType;
            dto.Amount = t.Amount;

            list.Add(dto);
        }

        return list;
    }

    public async Task<TransactionDto> GetById(int id)
    {
        var t = await _datacontext.Transactions.FindAsync(id);

        var dto = new TransactionDto();
        dto.Id = t.Id;
        dto.CustomerId = t.CustomerId;
        dto.TransactionType = t.TransactionType;
        dto.Amount = t.Amount;

        return dto;
    }

    public async Task Update(int id, CreateTransactionDto dto)
    {
        var transaction = await _datacontext.Transactions.FindAsync(id);
        var customer = await _datacontext.Customers.FindAsync(transaction.CustomerId);

        if (transaction.TransactionType == TransactionType.Credit)
            customer.Balance -= transaction.Amount;
        else
            customer.Balance += transaction.Amount;

        transaction.TransactionType = dto.TransactionType;
        transaction.Amount = dto.Amount;

        if (dto.TransactionType == TransactionType.Credit)
            customer.Balance += dto.Amount;
        else
            customer.Balance -= dto.Amount;

        await _datacontext.SaveChangesAsync();
    }
}