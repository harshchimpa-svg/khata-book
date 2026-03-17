using Application.Dites.Dto;
using AutoMapper;
using Data.Dites;
using Domain;

namespace Application.Dites
{
    public class DietApplication : IDietApplication
    {
        private readonly IDietRepository _dietRepository;
        private readonly IMapper _mapper;

        public DietApplication(IDietRepository dietRepository, IMapper mapper)
        {
            _dietRepository = dietRepository;
            _mapper = mapper;
        }

        public async Task<string> Create(CreateDietDto dto)
        {
            var diet = _mapper.Map<Diet>(dto);

            await _dietRepository.Create(diet);

            return "Diet Created";
        }

        public async Task Update(int id, CreateDietDto dto)
        {
            var diet = await _dietRepository.GetById(id);

            if (diet == null)
                throw new Exception("Diet not found");

            diet.DietTypeId = dto.DietTypeId;
            diet.Name = dto.Name;
            diet.Time = dto.Time;
            diet.Description = dto.Description;

            await _dietRepository.Update(diet);
        }

        public async Task Delete(int id)
        {
            await _dietRepository.Delete(id);
        }

        public async Task<List<DietDto>> GetAll()
        {
            var diets = await _dietRepository.GetAll();

            return _mapper.Map<List<DietDto>>(diets);
        }

        public async Task<DietDto> GetById(int id)
        {
            var diet = await _dietRepository.GetById(id);

            if (diet == null)
                return null;

            return _mapper.Map<DietDto>(diet);
        }
    }
}