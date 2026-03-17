using Application.Sales.Dto;
using AutoMapper;
using Data.Sales;
using Domain;

namespace Application.Sales
{
    public class SaleApplication : ISaleApplication
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public SaleApplication(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<string> Create(CreateSaleDto dto)
        {
            var sale = _mapper.Map<Sale>(dto);

            await _saleRepository.Create(sale);

            return "Sale Created";
        }

        public async Task Update(int id, CreateSaleDto dto)
        {
            var sale = await _saleRepository.GetById(id);

            if (sale == null)
                throw new Exception("Sale not found");

            sale.UserId = dto.UserId;
            sale.IsPaid = dto.IsPaid;
            sale.IsCanceld = dto.IsCanceld;
            sale.InvoiceNo = dto.InvoiceNo;
            sale.Discount = dto.Discount;
            sale.NetAmount = dto.NetAmount;
            sale.Tax = dto.Tax;

            await _saleRepository.Update(sale);
        }

        public async Task Delete(int id)
        {
            await _saleRepository.Delete(id);
        }

        public async Task<List<SaleDto>> GetAll()
        {
            var sales = await _saleRepository.GetAll();

            return _mapper.Map<List<SaleDto>>(sales);
        }

        public async Task<SaleDto> GetById(int id)
        {
            var sale = await _saleRepository.GetById(id);

            if (sale == null)
                return null;

            return _mapper.Map<SaleDto>(sale);
        }
    }
}