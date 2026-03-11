using Application.Abouts.Dto;

namespace Application.Abouts;

public interface IAboutApplication
{
    Task<string> Create(CreateAboutDto dto);
    Task Delete(int id);
    Task<List<AboutDto>> GetAll();
    Task<AboutDto> GetById(int id);
    Task Update(int Id, CreateAboutDto update);
}