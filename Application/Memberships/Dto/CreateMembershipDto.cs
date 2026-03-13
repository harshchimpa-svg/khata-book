namespace Application.Memberships.Dto;

public class CreateMembershipDto
{
    public int MembershipId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid UserId { get; set; }
}