using Domain;

namespace Data.Customers;

public interface ICustomerRepository
{
    Task Delete(int id);
    Task<Customer> GetById(int id);
    Task Update(Customer customer);
    Task<List<Customer>> GetAll();
    Task<Customer> Create(Customer customer);
}