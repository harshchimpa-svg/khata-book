using Application.Memberships.Dto;
using Data.Memberships;
using Domain;

namespace Application.Memberships;

public class MembershipApplication : IMembershipApplication
{
    private readonly IMembershipRepository _membershipRepository;

    public MembershipApplication(IMembershipRepository membershipRepository)
    {
        _membershipRepository = membershipRepository;
    }

    public async Task<string> Create(CreateMembershipDto dto)
    {
        var membership = new Membership
        {
            MembershipId = dto.MembershipId,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            UserId = dto.UserId
        };

        await _membershipRepository.Create(membership);

        return "Membership Created";
    }

    public async Task Update(int id, CreateMembershipDto dto)
    {
        var membership = await _membershipRepository.GetById(id);

        if (membership == null)
            throw new Exception("Membership not found");

        membership.MembershipId = dto.MembershipId;
        membership.StartDate = dto.StartDate;
        membership.EndDate = dto.EndDate;
        membership.UserId = dto.UserId;

        await _membershipRepository.Update(membership);
    }

    public async Task Delete(int id)
    {
        await _membershipRepository.Delete(id);
    }

    public async Task<List<MembershipDto>> GetAll()
    {
        var memberships = await _membershipRepository.GetAll();

        return memberships.Select(m => new MembershipDto
        {
            Id = m.Id,
            MembershipId = m.MembershipId,
            StartDate = m.StartDate,
            EndDate = m.EndDate,
            UserId = m.UserId
        }).ToList();
    }

    public async Task<MembershipDto> GetById(int id)
    {
        var membership = await _membershipRepository.GetById(id);

        if (membership == null)
            return null;

        return new MembershipDto
        {
            Id = membership.Id,
            MembershipId = membership.MembershipId,
            StartDate = membership.StartDate,
            EndDate = membership.EndDate,
            UserId = membership.UserId
        };
    }
}