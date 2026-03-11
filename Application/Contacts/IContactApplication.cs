using Application.Categories.Dto;
using Application.Contacts.Dto;

namespace Application.Contacts;

public interface IContactApplication
{
    Task<string> Create(CreateContactDto dto);
    Task Delete(int id);
    Task<List<ContactDto>> GetAll();
    Task<ContactDto> GetById(int id);
    Task Update(int Id, CreateContactDto update);
}