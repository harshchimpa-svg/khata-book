using Application.Memberships.Dto;

namespace Application.Memberships;

public interface IMembershipApplication
{
    Task<string> Create(CreateMembershipDto dto);
    Task Delete(int id);
    Task<List<MembershipDto>> GetAll();
    Task<MembershipDto> GetById(int id);
    Task Update(int Id, CreateMembershipDto update);
}