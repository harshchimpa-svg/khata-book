using Application.DiteTypes.Dto;
using AutoMapper;
using Data.DiteTypes;
using Domain;

namespace Application.DiteTypes;

public class DietTypeApplication : IDietTypeApplication
{
    private readonly IDietTypeRepository _dietRepository;
    private readonly IMapper _mapper;

    public DietTypeApplication(IDietTypeRepository dietRepository, IMapper mapper)
    {
        _dietRepository = dietRepository;
        _mapper = mapper;
    }

    public async Task<string> Create(CreateDietTypeDto dto)
    {
        var dietType = _mapper.Map<DietType>(dto);

        await _dietRepository.Create(dietType);

        return "Diet Created";
    }

    public async Task Update(int id, CreateDietTypeDto dto)
    {
        var diet = await _dietRepository.GetById(id);

        if (diet == null)
            throw new Exception("Diet not found");

        diet.Name = dto.Name;

        await _dietRepository.Update(diet);
    }

    public async Task Delete(int id)
    {
        await _dietRepository.Delete(id);
    }

    public async Task<List<DietTypeDto>> GetAll()
    {
        var diets = await _dietRepository.GetAll();

        return _mapper.Map<List<DietTypeDto>>(diets);
    }

    public async Task<DietTypeDto> GetById(int id)
    {
        var diet = await _dietRepository.GetById(id);

        if (diet == null)
            return null;

        return _mapper.Map<DietTypeDto>(diet);
    }
}