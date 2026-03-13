using Application.DiteTypes.Dto;

namespace Application.DiteTypes;

public interface IDietTypeApplication
{
    Task<string> Create(CreateDietTypeDto dto);
    Task Delete(int id);
    Task<List<DietTypeDto>> GetAll();
    Task<DietTypeDto> GetById(int id);
    Task Update(int id, CreateDietTypeDto update);
}