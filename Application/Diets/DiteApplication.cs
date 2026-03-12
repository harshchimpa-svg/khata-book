using Application.Dites.Dto;
using Data.Dites; 
using Domain;

namespace Application.Dites
{
    public class DietApplication : IDiteApplication
    {
        private readonly IDietRepository _dietRepository;

        public DietApplication(IDietRepository dietRepository)
        {
            _dietRepository = dietRepository;
        }

        public async Task<string> Create(CreateDietDto dto)
        {
            var diet = new Diet
            {
                DietTypeId = dto.DietTypeId,
                Name = dto.Name,
                Time = dto.Time,
                Description = dto.Description
            };

            await _dietRepository.Create(diet);
            return "Diet Created";
        }

        public async Task Update(int id, CreateDietDto dto)
        {
            var diet = await _dietRepository.GetById(id);
            if (diet == null) throw new Exception("Diet not found");

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

            return diets.Select(d => new DietDto
            {
                Id = d.Id,
                DietTypeId = d.DietTypeId,
                Name = d.Name,
                Time = d.Time,
                Description = d.Description
            }).ToList();
        }

        public async Task<DietDto> GetById(int id)
        {
            var diet = await _dietRepository.GetById(id);
            if (diet == null) return null;

            return new DietDto
            {
                Id = diet.Id,
                DietTypeId = diet.DietTypeId,
                Name = diet.Name,
                Time = diet.Time,
                Description = diet.Description
            };
        }
    }
}