using Application.Contacts;
using Application.Contacts.Dto;
using Data.Contacts;
using Domain;

namespace Application.Contacts;

public class ContactApplication : IContactApplication
{
    private readonly IContactRepository _contactRepository;

    public ContactApplication(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<string> Create(CreateContactDto dto)
    {
        var contact = new Contact
        {
            Name = dto.Name,
            Email = dto.Email,
            Message = dto.Message
        };

        await _contactRepository.Create(contact);
        return "Contact Created";
    }

    public async Task Update(int id, CreateContactDto dto)
    {
        var contact = await _contactRepository.GetById(id);
        if (contact == null) throw new Exception("Contact not found");

        contact.Name = dto.Name;
        contact.Email = dto.Email;
        contact.Message = dto.Message;

        await _contactRepository.Update(contact);
    }

    public async Task Delete(int id)
    {
        await _contactRepository.Delete(id);
    }

    public async Task<List<ContactDto>> GetAll()
    {
        var contacts = await _contactRepository.GetAll();

        return contacts.Select(c => new ContactDto
        {
            Id = c.Id,
            Name = c.Name,
            Email = c.Email,
            Message = c.Message
        }).ToList();
    }

    public async Task<ContactDto> GetById(int id)
    {
        var contact = await _contactRepository.GetById(id);
        if (contact == null) return null;

        return new ContactDto
        {
            Id = contact.Id,
            Name = contact.Name,
            Email = contact.Email,
            Message = contact.Message
        };
    }
}