namespace Application.Memberships.Dto;

public class MembershipDto
{
    public int Id { get; set; }
    public int MembershipId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string UserId { get; set; }
}