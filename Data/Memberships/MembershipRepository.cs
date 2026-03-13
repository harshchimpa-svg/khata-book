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
        var membership = await _context.Memberships.FindAsync(id);
        _context.Memberships.Remove(membership);
        await _context.SaveChangesAsync();   
    }
    public async Task<List<Membership>> GetAll()
    {
        var membership = await _context.Memberships.ToListAsync();
        return membership;
    }

    public async Task<Membership> GetById(int id)
    {
        return await _context.Memberships.FindAsync(id);
    }
    public async Task<Membership> Create(Membership membership)
    {
        await _context.Memberships.AddAsync(membership);
        await _context.SaveChangesAsync();

        return membership;
    }

    public async Task Update(Membership membership)
    {
        _context.Memberships.Update(membership);
        await _context.SaveChangesAsync();
    }
}