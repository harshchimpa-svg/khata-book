using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Memberships;

public class MembershipRepository:IMembershipRepository
{
    private readonly DataContext _context;

    public MembershipRepository(DataContext context)
    {   
        _context = context;
    }

    public async Task Delete(int id)    
    {
        var about = await _context.Memberships.FindAsync(id);
        _context.Memberships.Remove(about);
        await _context.SaveChangesAsync();   
    }
    public async Task<List<Membership>> GetAll()
    {
        var about = await _context.Memberships.ToListAsync();
        return about;
    }

    public async Task<Membership> GetById(int id)
    {
        return await _context.Memberships.FindAsync(id);
    }
    public async Task<Membership> Create(Membership about)
    {
        await _context.Memberships.AddAsync(about);
        await _context.SaveChangesAsync();

        return about;
    }

    public async Task Update(Membership about)
    {
        _context.Memberships.Update(about);
        await _context.SaveChangesAsync();
    }
}