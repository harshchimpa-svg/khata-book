using Application.GymProducts.Dto;
using Application.Gyms.Dto;

namespace Application.Gyms;

public interface IGymApplication
{
    Task<string> Create(CreateGymDto dto);
    Task Delete(int id);
    Task<List<GymDto>> GetAll();
    Task<GymDto> GetById(int id);
    Task Update(int Id, CreateGymDto update);
}