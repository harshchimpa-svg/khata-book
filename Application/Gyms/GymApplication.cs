using Application.Gyms.Dto;
using Data.Gyms;
using Domain;

namespace Application.Gyms
{
    public class GymApplication : IGymApplication
    {
        private readonly IGymRepository _gymRepository;

        public GymApplication(IGymRepository gymRepository)
        {
            _gymRepository = gymRepository;
        }

        public async Task<string> Create(CreateGymDto dto)
        {
            var gym = new Gym
            {
                Name = dto.Name,
                Price = dto.Price,
                Description = dto.Description,
                LocationId = dto.LocationId
            };

            await _gymRepository.Create(gym);
            return "Gym Created";
        }

        public async Task Update(int id, CreateGymDto dto)
        {
            var gym = await _gymRepository.GetById(id);

            if (gym == null)
                throw new Exception("Gym not found");

            gym.Name = dto.Name;
            gym.Price = dto.Price;
            gym.Description = dto.Description;
            gym.LocationId = dto.LocationId;

            await _gymRepository.Update(gym);
        }

        public async Task Delete(int id)
        {
            await _gymRepository.Delete(id);
        }

        public async Task<List<GymDto>> GetAll()
        {
            var gyms = await _gymRepository.GetAll();

            return gyms.Select(g => new GymDto
            {
                Id = g.Id,
                Name = g.Name,
                Price = g.Price,
                Description = g.Description,
                LocationId = g.LocationId
            }).ToList();
        }

        public async Task<GymDto> GetById(int id)
        {
            var gym = await _gymRepository.GetById(id);

            if (gym == null)
                return null;

            return new GymDto
            {
                Id = gym.Id,
                Name = gym.Name,
                Price = gym.Price,
                Description = gym.Description,
                LocationId = gym.LocationId
            };
        }
    }
}