using Application.GymProducts.Dto;

namespace Application.GymProducts;

public interface IGymProductApplication
{
    Task<string> Create(CreateGymProductDto dto);
    Task Delete(int id);
    Task<List<GymProductDto>> GetAll();
    Task<GymProductDto> GetById(int id);
    Task Update(int Id, CreateGymProductDto update);
}