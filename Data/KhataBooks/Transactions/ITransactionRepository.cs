using Domain;

namespace Data.Transactions;

public interface ITransactionRepository
{
    Task Delete(int id);
    Task<Transaction> GetById(int id);
    Task Update(Transaction shopsetting);
    Task<List<Transaction>> GetAll();
    Task<Transaction> Create(Transaction shopsetting);
}