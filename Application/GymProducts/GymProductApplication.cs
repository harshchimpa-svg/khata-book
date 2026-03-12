using Application.GymProducts.Dto;
using Data.GymProducts;
using Domain;

namespace Application.GymProducts
{
    public class GymProductApplication : IGymProductApplication
    {
        private readonly IGymProductRepository _gymProductRepository;

        public GymProductApplication(IGymProductRepository gymProductRepository)
        {
            _gymProductRepository = gymProductRepository;
        }

        public async Task<string> Create(CreateGymProductDto dto)
        {
            var product = new GymProduct
            {
                Tax = dto.Tax,
                Price = dto.Price,
                CategoryId = dto.CategoryId
            };

            await _gymProductRepository.Create(product);
            return "Gym Product Created";
        }

        public async Task Update(int id, CreateGymProductDto dto)
        {
            var product = await _gymProductRepository.GetById(id);

            if (product == null)
                throw new Exception("Gym Product not found");

            product.Tax = dto.Tax;
            product.Price = dto.Price;
            product.CategoryId = dto.CategoryId;

            await _gymProductRepository.Update(product);
        }

        public async Task Delete(int id)
        {
            await _gymProductRepository.Delete(id);
        }

        public async Task<List<GymProductDto>> GetAll()
        {
            var products = await _gymProductRepository.GetAll();

            return products.Select(p => new GymProductDto
            {
                Id = p.Id,
                Tax = p.Tax,
                Price = p.Price,
                CategoryId = p.CategoryId
            }).ToList();
        }

        public async Task<GymProductDto> GetById(int id)
        {
            var product = await _gymProductRepository.GetById(id);

            if (product == null)
                return null;

            return new GymProductDto
            {
                Id = product.Id,
                Tax = product.Tax,
                Price = product.Price,
                CategoryId = product.CategoryId
            };
        }
    }
}