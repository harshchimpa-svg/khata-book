using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Customers;

public class CustomerRepository:ICustomerRepository
{
    private readonly DataContext _context;

    public CustomerRepository(DataContext context)
    {   
        _context = context;
    }

    public async Task Delete(int id)    
    {
        var customer = await _context.Customers.FindAsync(id);
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();  
    }
    public async Task<List<Customer>> GetAll()
    {
        var customer = await _context.Customers.ToListAsync();
        return customer;
    }

    public async Task<Customer> GetById(int id)
    {
        return await _context.Customers.FindAsync(id);
    }
    public async Task<Customer> Create(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();

        return customer;
    }

    public async Task Update(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }
}