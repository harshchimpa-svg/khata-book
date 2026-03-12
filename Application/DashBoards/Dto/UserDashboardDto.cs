namespace Application.DashBoards.Dto;

public class UserDashboardDto
{
    public decimal TotalCredit { get; set; }
    public decimal TotalDebit { get; set; }
    public decimal Balance { get; set; }
    public int TransactionCount { get; set; }
}