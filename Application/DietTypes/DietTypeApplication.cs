using System.Security.Claims;
using Application.Dites.Dto;
using Application.DiteTypes.Dto;
using Data;
using Data.DiteTypes;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.DiteTypes;

public class DietTypeApplication : IDietTypeApplication
{
    private readonly IDietTypeRepository _dietRepository;

    public DietTypeApplication(IDietTypeRepository dietRepository)
    {
        _dietRepository = dietRepository;
    }

    public async Task<string> Create(CreateDietTypeDto dto)
    {
        var diet = new DietType
        {
            Name = dto.Name,
        };

        await _dietRepository.Create(diet);
        return "Diet Created";
    }

    public async Task Update(int id, CreateDietTypeDto dto)
    {
        var diet = await _dietRepository.GetById(id);
        if (diet == null) throw new Exception("Diet not found");

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

        return diets.Select(d => new DietTypeDto
        {
            Id = d.Id,
            Name = d.Name,
        }).ToList();
    }

    public async Task<DietTypeDto> GetById(int id)
    {
        var diet = await _dietRepository.GetById(id);
        if (diet == null) return null;

        return new DietTypeDto
        {
            Id = diet.Id,
            Name = diet.Name,
        };
    }
}
