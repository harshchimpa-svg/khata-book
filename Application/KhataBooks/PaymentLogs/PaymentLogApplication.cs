using System.Security.Claims;
using Application.PaymentLogs.Dto;
using Application.Transactions.Dto;
using Data.PaymentLogs;
using Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Application.PaymentLogs
{
    public class PaymentLogApplication : IPaymentLogApplication
    {
        private readonly IPaymentLogRepository _paymentLogRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PaymentLogApplication(
            IPaymentLogRepository paymentLogRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _paymentLogRepository = paymentLogRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        private string GetUserId()
        {
            var userId = _httpContextAccessor.HttpContext?.User?
                .FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
                throw new Exception("User not authenticated");

            return userId;
        }

        public async Task<List<PaymentLogDto>> GetAll()
        {
            var userId = GetUserId();

            var transactions = await _paymentLogRepository.GetAll();

            var paymentLogs = transactions
                .Where(x => x.Customer.UserId == userId)
                .GroupBy(transaction => transaction.CustomerId)
                .Select(customerGroup => new PaymentLogDto
                {
                    CustomerId = customerGroup.Key,
                    CustomerName = customerGroup.FirstOrDefault()?.Customer?.Name ?? "Unknown",

                    TotalCredit = customerGroup
                        .Where(transaction => transaction.TransactionType == TransactionType.Credit)
                        .Sum(transaction => transaction.Amount),

                    TotalDebit = customerGroup
                        .Where(transaction => transaction.TransactionType == TransactionType.Debit)
                        .Sum(transaction => transaction.Amount),

                    Transactions = customerGroup
                        .Select(transaction => new TransactionDto
                        {
                            Id = transaction.Id,
                            Amount = transaction.Amount,
                            TransactionType = transaction.TransactionType
                        })
                        .ToList()
                })
                .ToList();

            return paymentLogs;
        }
    }
}