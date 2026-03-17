using Application.Gyms.Dto;
using AutoMapper;
using Data.Gyms;
using Domain;

namespace Application.Gyms
{
    public class GymApplication : IGymApplication
    {
        private readonly IGymRepository _gymRepository;
        private readonly IMapper _mapper;

        public GymApplication(IGymRepository gymRepository, IMapper mapper)
        {
            _gymRepository = gymRepository;
            _mapper = mapper;
        }

        public async Task<string> Create(CreateGymDto dto)
        {
            var gym = _mapper.Map<Gym>(dto);

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

            return _mapper.Map<List<GymDto>>(gyms);
        }

        public async Task<GymDto> GetById(int id)
        {
            var gym = await _gymRepository.GetById(id);

            if (gym == null)
                return null;

            return _mapper.Map<GymDto>(gym);
        }
    }
}