using Application.locations.Dto;
using AutoMapper;
using Data.Locations;
using Domain;

namespace Application.locations
{
    public class LocationApplication : ILocationApplications
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationApplication(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<string> Create(CreateLocationDto dto)
        {
            var location = _mapper.Map<Location>(dto);

            await _locationRepository.Create(location);

            return "Location Created";
        }

        public async Task Update(int locationId, CreateLocationDto dto)
        {
            var location = await _locationRepository.GetId(locationId);

            if (location == null)
                throw new Exception("Location not found");

            location.Name = dto.Name;
            location.ParentId = dto.ParentId;
            location.LocationType = dto.LocationType;

            await _locationRepository.Update(location);
        }

        public async Task Delete(int id)
        {
            await _locationRepository.Delete(id);
        }

        public async Task<List<LocationDto>> GetAll()
        {
            var locations = await _locationRepository.GetAll();

            return _mapper.Map<List<LocationDto>>(locations);
        }

        public async Task<LocationDto> GetById(int id)
        {
            var location = await _locationRepository.GetId(id);

            if (location == null)
                return null;

            return _mapper.Map<LocationDto>(location);
        }
    }
}