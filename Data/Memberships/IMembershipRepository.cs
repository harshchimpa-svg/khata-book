using Domain;

namespace Data.Memberships;

public interface IMembershipRepository
{
    Task Delete(int id);
    Task<Membership> GetById(int id);
    Task Update(Membership membership);
    Task<List<Membership>> GetAll();
    Task<Membership> Create(Membership membership);
}