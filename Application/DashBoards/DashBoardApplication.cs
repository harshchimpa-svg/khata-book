using System.Security.Claims;
using Application.DashBoards.Dto;
using Data;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.DashBoards
{
    public class DashBoardApplication : IDashBoardApplication
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashBoardApplication(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserDashboardDto> GetUserDashboardAsync(CancellationToken cancellationToken = default)
        {
            // JWT token se current user ka ID nikalna
            var userId = _httpContextAccessor.HttpContext?.User
                ?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(userId))
                return null; // controller me NotFound handle hoga

            var transactions = await _context.Transactions
                .AsNoTracking()
                .Where(x => x.CreatedBy == userId)
                .ToListAsync(cancellationToken);

            var totalCredit = transactions
                .Where(x => x.TransactionType == TransactionType.Credit)
                .Sum(x => x.Amount);

            var totalDebit = transactions
                .Where(x => x.TransactionType == TransactionType.Debit)
                .Sum(x => x.Amount);

            return new UserDashboardDto
            {
                TotalCredit = totalCredit,
                TotalDebit = totalDebit,
                Balance = totalCredit - totalDebit,
                TransactionCount = transactions.Count
            };
        }
    }
}