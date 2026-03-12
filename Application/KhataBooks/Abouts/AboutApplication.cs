using System.Security.Claims;
using Application.Abouts.Dto;
using Data.Aboutes;
using Data.Services;
using Domain;
using Microsoft.AspNetCore.Http;

namespace Application.Abouts;

public class AboutApplication : IAboutApplication
{
    private readonly IAboutRepository _aboutRepository;
    private readonly IFileService _fileService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AboutApplication(
        IAboutRepository aboutRepository,
        IFileService fileService,
        IHttpContextAccessor httpContextAccessor)
    {
        _aboutRepository = aboutRepository;
        _fileService = fileService;
        _httpContextAccessor = httpContextAccessor;
    }

    private string GetUserId()
    {
        var userId = _httpContextAccessor.HttpContext?.User?
            .FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
            throw new Exception("User not authenticated");

        return userId;
    }

    public async Task<string> Create(CreateAboutDto dto)
    {
        string userId = GetUserId();

        var imagePath = await _fileService.UploadImage(dto.Profile, "about");

        var about = new About
        {
            Name = dto.Name,
            Profile = imagePath,
            SubTitel = dto.SubTitel,
            UserId = userId
        };

        await _aboutRepository.Create(about);

        return "About Created";
    }

    public async Task Delete(int id)
    {
        var userId = GetUserId();

        var about = await _aboutRepository.GetById(id);

        if (about == null || about.UserId != userId)
            throw new Exception("Unauthorized access");

        await _aboutRepository.Delete(id);
    }

    public async Task<List<AboutDto>> GetAll()
    {
        var userId = GetUserId();

        var abouts = await _aboutRepository.GetAll();

        return abouts
            .Where(x => x.UserId == userId)
            .Select(x => new AboutDto
            {
                Id = x.Id,
                Name = x.Name,
                Profile = x.Profile,
                SubTitel = x.SubTitel,
                UserId = x.UserId
            }).ToList();
    }

    public async Task<AboutDto> GetById(int id)
    {
        var userId = GetUserId();

        var about = await _aboutRepository.GetById(id);

        if (about == null || about.UserId != userId)
            throw new Exception("Unauthorized access");

        return new AboutDto
        {
            Id = about.Id,
            Name = about.Name,
            Profile = about.Profile,
            SubTitel = about.SubTitel,
            UserId = about.UserId
        };
    }

    public async Task Update(int id, CreateAboutDto input)
    {
        var userId = GetUserId();

        var about = await _aboutRepository.GetById(id);

        if (about == null || about.UserId != userId)
            throw new Exception("Unauthorized access");

        if (input.Profile != null)
        {
            var imagePath = await _fileService.UploadImage(input.Profile, "about");
            about.Profile = imagePath;
        }

        about.Name = input.Name;
        about.SubTitel = input.SubTitel;

        await _aboutRepository.Update(about);
    }
}