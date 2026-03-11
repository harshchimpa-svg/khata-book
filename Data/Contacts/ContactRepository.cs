using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Contacts;

public class ContactRepository:IContactRepository
{
    private readonly DataContext _context;

    public ContactRepository(DataContext context)
    {   
        _context = context;
    }

    public async Task Delete(int id)    
    {
        var contact = await _context.Contacts.FindAsync(id);
        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync();   
    }
    public async Task<List<Contact>> GetAll()
    {
        var contact = await _context.Contacts.ToListAsync();
        return contact;
    }

    public async Task<Contact> GetById(int id)
    {
        return await _context.Contacts.FindAsync(id);
    }
    public async Task<Contact> Create(Contact contact)
    {
        await _context.Contacts.AddAsync(contact);
        await _context.SaveChangesAsync();

        return contact;
    }

    public async Task Update(Contact contact)
    {
        _context.Contacts.Update(contact);
        await _context.SaveChangesAsync();
    }
}