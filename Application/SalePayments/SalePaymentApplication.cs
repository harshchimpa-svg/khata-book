using Application.SalePayments.Dto;
using Data.SalePayments;
using Domain;

namespace Application.SalePayments
{
    public class SalePaymentApplication : ISalePaymentApplication
    {
        private readonly ISalePaymentRepository _salePaymentRepository;

        public SalePaymentApplication(ISalePaymentRepository salePaymentRepository)
        {
            _salePaymentRepository = salePaymentRepository;
        }

        public async Task<string> Create(CreateSalePaymentDto dto)
        {
            var payment = new SalePayment
            {
                SaleId = dto.SaleId,
                MethodType = dto.MethodType,
                NetAmount = dto.NetAmount,
                PaymentDate = dto.PaymentDate,
                StatusType = dto.StatusType
            };

            await _salePaymentRepository.Create(payment);
            return "Sale Payment Created";
        }

        public async Task Update(int id, CreateSalePaymentDto dto)
        {
            var payment = await _salePaymentRepository.GetById(id);

            if (payment == null)
                throw new Exception("Sale Payment not found");

            payment.SaleId = dto.SaleId;
            payment.MethodType = dto.MethodType;
            payment.NetAmount = dto.NetAmount;
            payment.PaymentDate = dto.PaymentDate;
            payment.StatusType = dto.StatusType;

            await _salePaymentRepository.Update(payment);
        }

        public async Task Delete(int id)
        {
            await _salePaymentRepository.Delete(id);
        }

        public async Task<List<SalePaymentDto>> GetAll()
        {
            var payments = await _salePaymentRepository.GetAll();

            return payments.Select(p => new SalePaymentDto
            {
                Id = p.Id,
                SaleId = p.SaleId,
                MethodType = p.MethodType,
                NetAmount = p.NetAmount,
                PaymentDate = p.PaymentDate,
                StatusType = p.StatusType
            }).ToList();
        }

        public async Task<SalePaymentDto> GetById(int id)
        {
            var payment = await _salePaymentRepository.GetById(id);

            if (payment == null)
                return null;

            return new SalePaymentDto
            {
                Id = payment.Id,
                SaleId = payment.SaleId,
                MethodType = payment.MethodType,
                NetAmount = payment.NetAmount,
                PaymentDate = payment.PaymentDate,
                StatusType = payment.StatusType
            };
        }
    }
}