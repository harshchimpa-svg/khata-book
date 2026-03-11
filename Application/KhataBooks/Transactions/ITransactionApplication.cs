using Application.Transactions.Dto;

namespace Application.Transactions;

public interface ITransactionApplication
{
    Task<string> Create(CreateTransactionDto dto);
    Task Delete(int id);
    Task<List<TransactionDto>> GetAll();
    Task<TransactionDto> GetById(int id);
    Task Update(int id, CreateTransactionDto update);
}