using Application.SaleProducts.Dto;
using Data.SaleProducts;
using Domain;

namespace Application.SaleProducts
{
    public class SaleProductApplication : ISaleProductApplication
    {
        private readonly ISaleProductRepository _saleProductRepository;

        public SaleProductApplication(ISaleProductRepository saleProductRepository)
        {
            _saleProductRepository = saleProductRepository;
        }

        public async Task<string> Create(CreateSaleProductDto dto)
        {
            var saleProduct = new SaleProduct
            {
                SaleId = dto.SaleId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                Price = dto.Price,
                Discount = dto.Discount,
                Tax = dto.Tax
            };

            await _saleProductRepository.Create(saleProduct);
            return "Sale Product Created";
        }

        public async Task Update(int id, CreateSaleProductDto dto)
        {
            var saleProduct = await _saleProductRepository.GetById(id);

            if (saleProduct == null)
                throw new Exception("Sale Product not found");

            saleProduct.SaleId = dto.SaleId;
            saleProduct.ProductId = dto.ProductId;
            saleProduct.Quantity = dto.Quantity;
            saleProduct.Price = dto.Price;
            saleProduct.Discount = dto.Discount;
            saleProduct.Tax = dto.Tax;

            await _saleProductRepository.Update(saleProduct);
        }

        public async Task Delete(int id)
        {
            await _saleProductRepository.Delete(id);
        }

        public async Task<List<SaleProductDto>> GetAll()
        {
            var saleProducts = await _saleProductRepository.GetAll();

            return saleProducts.Select(s => new SaleProductDto
            {
                Id = s.Id,
                SaleId = s.SaleId,
                ProductId = s.ProductId,
                Quantity = s.Quantity,
                Price = s.Price,
                Discount = s.Discount,
                Tax = s.Tax
            }).ToList();
        }

        public async Task<SaleProductDto> GetById(int id)
        {
            var saleProduct = await _saleProductRepository.GetById(id);

            if (saleProduct == null)
                return null;

            return new SaleProductDto
            {
                Id = saleProduct.Id,
                SaleId = saleProduct.SaleId,
                ProductId = saleProduct.ProductId,
                Quantity = saleProduct.Quantity,
                Price = saleProduct.Price,
                Discount = saleProduct.Discount,
                Tax = saleProduct.Tax
            };
        }
    }
}