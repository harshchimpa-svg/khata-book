using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Membership
{
    public int Id { get; set; }
    public int MembershipId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    [ForeignKey("User")]
    public Guid UserId { get; set; }
    public User User { get; set; }
}