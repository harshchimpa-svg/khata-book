using Application.Customers.Dto;

namespace Application.Customers;

public interface ICustomerApplication
{
    Task<string> Create(CreateCustomerDto dto);
    Task Delete(int id);
    Task<List<CustomerDto>> GetAll();
    Task<CustomerDto> GetById(int id);
    Task Update(int Id, CreateCustomerDto update);
    Task<string> SendReminder();
    Task<string> BlockCustomer(int id);
}