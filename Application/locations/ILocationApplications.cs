using Application.locations.Dto;
using Domain;

namespace Application.locations
{
    public interface ILocationApplications
    {
        Task<string> Create(CreateLocationDto dto);
        Task Delete(int id);
        Task<List<LocationDto>> GetAll();
        Task<LocationDto> GetById(int id);
        Task Update(int LocationId, CreateLocationDto update);
    }
}
