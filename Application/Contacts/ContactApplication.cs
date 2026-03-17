using Application.Contacts.Dto;
using AutoMapper;
using Data.Contacts;
using Domain;

namespace Application.Contacts;

public class ContactApplication : IContactApplication
{
    private readonly IContactRepository _contactRepository;
    private readonly IMapper _mapper;

    public ContactApplication(IContactRepository contactRepository, IMapper mapper)
    {
        _contactRepository = contactRepository;
        _mapper = mapper;
    }

    public async Task<string> Create(CreateContactDto dto)
    {
        var contact = _mapper.Map<Contact>(dto);

        await _contactRepository.Create(contact);

        return "Contact Created";
    }

    public async Task Update(int id, CreateContactDto dto)
    {
        var contact = await _contactRepository.GetById(id);

        if (contact == null)
            throw new Exception("Contact not found");

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

        return _mapper.Map<List<ContactDto>>(contacts);
    }

    public async Task<ContactDto> GetById(int id)
    {
        var contact = await _contactRepository.GetById(id);

        if (contact == null)
            return null;

        return _mapper.Map<ContactDto>(contact);
    }
}