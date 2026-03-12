namespace Application.Dites.Dto;

public interface IDietApplication
{
    Task<string> Create(CreateDietDto dto);
    Task Delete(int id);
    Task<List<DietDto>> GetAll();
    Task<DietDto> GetById(int id);
    Task Update(int Id, CreateDietDto update);
}