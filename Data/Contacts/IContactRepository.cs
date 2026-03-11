
using Domain;

namespace Data.Contacts;

public interface IContactRepository
{
    Task Delete(int id);
    Task<Contact> GetById(int id);
    Task Update(Contact category);
    Task<List<Contact>> GetAll();
    Task<Contact> Create(Contact category);
}