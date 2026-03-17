using Application.GymProducts.Dto;
using AutoMapper;
using Data.GymProducts;
using Domain;

namespace Application.GymProducts
{
    public class GymProductApplication : IGymProductApplication
    {
        private readonly IGymProductRepository _gymProductRepository;
        private readonly IMapper _mapper;

        public GymProductApplication(IGymProductRepository gymProductRepository, IMapper mapper)
        {
            _gymProductRepository = gymProductRepository;
            _mapper = mapper;
        }

        public async Task<string> Create(CreateGymProductDto dto)
        {
            var product = _mapper.Map<GymProduct>(dto);

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

            return _mapper.Map<List<GymProductDto>>(products);
        }

        public async Task<GymProductDto> GetById(int id)
        {
            var product = await _gymProductRepository.GetById(id);

            if (product == null)
                return null;

            return _mapper.Map<GymProductDto>(product);
        }
    }
}