using Application.Memberships.Dto;
using AutoMapper;
using Data.Memberships;
using Domain;

namespace Application.Memberships;

public class MembershipApplication : IMembershipApplication
{
    private readonly IMembershipRepository _membershipRepository;
    private readonly IMapper _mapper;

    public MembershipApplication(IMembershipRepository membershipRepository, IMapper mapper)
    {
        _membershipRepository = membershipRepository;
        _mapper = mapper;
    }

    public async Task<string> Create(CreateMembershipDto dto)
    {
        var membership = _mapper.Map<Membership>(dto);

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

        return _mapper.Map<List<MembershipDto>>(memberships);
    }

    public async Task<MembershipDto> GetById(int id)
    {
        var membership = await _membershipRepository.GetById(id);

        if (membership == null)
            return null;

        return _mapper.Map<MembershipDto>(membership);
    }
}