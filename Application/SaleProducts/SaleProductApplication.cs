using Application.SaleProducts.Dto;
using AutoMapper;
using Data.SaleProducts;
using Domain;

namespace Application.SaleProducts
{
    public class SaleProductApplication : ISaleProductApplication
    {
        private readonly ISaleProductRepository _saleProductRepository;
        private readonly IMapper _mapper;

        public SaleProductApplication(ISaleProductRepository saleProductRepository, IMapper mapper)
        {
            _saleProductRepository = saleProductRepository;
            _mapper = mapper;
        }

        public async Task<string> Create(CreateSaleProductDto dto)
        {
            var saleProduct = _mapper.Map<SaleProduct>(dto);

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

            return _mapper.Map<List<SaleProductDto>>(saleProducts);
        }

        public async Task<SaleProductDto> GetById(int id)
        {
            var saleProduct = await _saleProductRepository.GetById(id);

            if (saleProduct == null)
                return null;

            return _mapper.Map<SaleProductDto>(saleProduct);
        }
    }
}