using Application.DashBoards;
using Application.DashBoards.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/dashboard")]
    [ApiController]
    
    public class DashBoardController : ControllerBase
    {
        private readonly IDashBoardApplication _dashBoardApplication;

        public DashBoardController(IDashBoardApplication dashBoardApplication)
        {
            _dashBoardApplication = dashBoardApplication;
        }

        [Authorize(Roles =  "Admin,Employee")]
        [HttpGet]
        public async Task<IActionResult> GetUserDashboard(CancellationToken cancellationToken)
        {
            var dashboard = await _dashBoardApplication.GetUserDashboardAsync(cancellationToken);

            if (dashboard == null)
                return NotFound("User not authenticated or no transactions found.");

            return Ok(dashboard);
        }
    }
}