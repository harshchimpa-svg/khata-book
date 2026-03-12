using Application.DashBoards.Dto;

namespace Application.DashBoards;

public interface IDashBoardApplication
{
    Task<UserDashboardDto> GetUserDashboardAsync( CancellationToken cancellationToken);
}