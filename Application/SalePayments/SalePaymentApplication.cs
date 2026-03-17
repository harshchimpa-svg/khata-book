using Application.SalePayments.Dto;
using AutoMapper;
using Data.SalePayments;
using Domain;

namespace Application.SalePayments
{
    public class SalePaymentApplication : ISalePaymentApplication
    {
        private readonly ISalePaymentRepository _salePaymentRepository;
        private readonly IMapper _mapper;

        public SalePaymentApplication(ISalePaymentRepository salePaymentRepository, IMapper mapper)
        {
            _salePaymentRepository = salePaymentRepository;
            _mapper = mapper;
        }

        public async Task<string> Create(CreateSalePaymentDto dto)
        {
            var payment = _mapper.Map<SalePayment>(dto);

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

            return _mapper.Map<List<SalePaymentDto>>(payments);
        }

        public async Task<SalePaymentDto> GetById(int id)
        {
            var payment = await _salePaymentRepository.GetById(id);

            if (payment == null)
                return null;

            return _mapper.Map<SalePaymentDto>(payment);
        }
    }
}