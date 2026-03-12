using System.Security.Claims;
using Application.Transactions.Dto;
using Data;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Transactions;

public class TransactionApplication : ITransactionApplication
{
    private readonly DataContext _datacontext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TransactionApplication(
        DataContext datacontext,
        IHttpContextAccessor httpContextAccessor)
    {
        _datacontext = datacontext;
        _httpContextAccessor = httpContextAccessor;
    }

    private string GetUserId()
    {
        var userId = _httpContextAccessor.HttpContext?.User?
            .FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
            throw new Exception("User not authenticated");

        return userId;
    }

    public async Task<string> Create(CreateTransactionDto dto)
    {
        var userId = GetUserId();

        var customer = await _datacontext.Customers
            .FirstOrDefaultAsync(x => x.Id == dto.CustomerId && x.UserId == userId);

        if (customer == null)
            throw new Exception("Customer not found or unauthorized");

        var transaction = new Transaction
        {
            CustomerId = dto.CustomerId,
            TransactionType = dto.TransactionType,
            Amount = dto.Amount
        };

        await _datacontext.Transactions.AddAsync(transaction);

        if (dto.TransactionType == TransactionType.Credit)
            customer.Balance += dto.Amount;
        else
            customer.Balance -= dto.Amount;

        var paymentLog = new PaymentLog
        {
            CustomerId = customer.Id,
            Amount = dto.Amount,
            TransactionType = dto.TransactionType
        };

        await _datacontext.PaymentLogs.AddAsync(paymentLog);

        await _datacontext.SaveChangesAsync();

        return "Transaction created successfully";
    }

    public async Task Delete(int id)
    {
        var userId = GetUserId();

        var transaction = await _datacontext.Transactions
            .FirstOrDefaultAsync(x => x.Id == id);

        if (transaction == null)
            throw new Exception("Transaction not found");

        var customer = await _datacontext.Customers
            .FirstOrDefaultAsync(x => x.Id == transaction.CustomerId && x.UserId == userId);

        if (customer == null)
            throw new Exception("Unauthorized access");

        if (transaction.TransactionType == TransactionType.Credit)
            customer.Balance -= transaction.Amount;
        else
            customer.Balance += transaction.Amount;

        _datacontext.Transactions.Remove(transaction);

        await _datacontext.SaveChangesAsync();
    }

    public async Task<List<TransactionDto>> GetAll()
    {
        var userId = GetUserId();

        var transactions = await _datacontext.Transactions
            .Include(x => x.Customer)
            .Where(x => x.Customer.UserId == userId)
            .ToListAsync();

        var list = new List<TransactionDto>();

        foreach (var t in transactions)
        {
            var dto = new TransactionDto
            {
                Id = t.Id,
                CustomerId = t.CustomerId,
                TransactionType = t.TransactionType,
                Amount = t.Amount
            };

            list.Add(dto);
        }

        return list;
    }

    public async Task<TransactionDto> GetById(int id)
    {
        var userId = GetUserId();

        var t = await _datacontext.Transactions
            .Include(x => x.Customer)
            .FirstOrDefaultAsync(x => x.Id == id && x.Customer.UserId == userId);

        if (t == null)
            throw new Exception("Transaction not found or unauthorized");

        return new TransactionDto
        {
            Id = t.Id,
            CustomerId = t.CustomerId,
            TransactionType = t.TransactionType,
            Amount = t.Amount
        };
    }

    public async Task Update(int id, CreateTransactionDto dto)
    {
        var userId = GetUserId();

        var transaction = await _datacontext.Transactions
            .Include(x => x.Customer)
            .FirstOrDefaultAsync(x => x.Id == id && x.Customer.UserId == userId);

        if (transaction == null)
            throw new Exception("Transaction not found or unauthorized");

        var customer = transaction.Customer;

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