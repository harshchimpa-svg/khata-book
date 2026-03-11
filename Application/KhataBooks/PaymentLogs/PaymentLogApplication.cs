using Application.PaymentLogs.Dto;
using Application.Transactions.Dto;
using Data.PaymentLogs;
using Domain.Enums;

namespace Application.PaymentLogs
{
    public class PaymentLogApplication : IPaymentLogApplication
    {
        private readonly IPaymentLogRepository _paymentLogRepository;

        public PaymentLogApplication(IPaymentLogRepository paymentLogRepository)
        {
            _paymentLogRepository = paymentLogRepository;
        }

        public async Task<List<PaymentLogDto>> GetAll()
        {
            var transactions = await _paymentLogRepository.GetAll();

            var paymentLogs = transactions
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