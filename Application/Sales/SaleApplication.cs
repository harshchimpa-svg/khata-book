using Application.Sales.Dto;
using Data.Sales;
using Domain;

namespace Application.Sales
{
    public class SaleApplication : ISaleApplication
    {
        private readonly ISaleRepository _saleRepository;

        public SaleApplication(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<string> Create(CreateSaleDto dto)
        {
            var sale = new Sale
            {
                UserId = dto.UserId,
                IsPaid = dto.IsPaid,
                IsCanceld = dto.IsCanceld,
                InvoiceNo = dto.InvoiceNo,
                Discount = dto.Discount,
                NetAmount = dto.NetAmount,
                Tax = dto.Tax
            };

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

            return sales.Select(s => new SaleDto
            {
                Id = s.Id,
                UserId = s.UserId,
                IsPaid = s.IsPaid,
                IsCanceld = s.IsCanceld,
                InvoiceNo = s.InvoiceNo,
                Discount = s.Discount,
                NetAmount = s.NetAmount,
                Tax = s.Tax
            }).ToList();
        }

        public async Task<SaleDto> GetById(int id)
        {
            var sale = await _saleRepository.GetById(id);

            if (sale == null)
                return null;

            return new SaleDto
            {
                Id = sale.Id,
                UserId = sale.UserId,
                IsPaid = sale.IsPaid,
                IsCanceld = sale.IsCanceld,
                InvoiceNo = sale.InvoiceNo,
                Discount = sale.Discount,
                NetAmount = sale.NetAmount,
                Tax = sale.Tax
            };
        }
    }
}