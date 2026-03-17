using System.Security.Claims;
using Application.Abouts.Dto;
using AutoMapper;
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
    private readonly IMapper _mapper;

    public AboutApplication(
        IAboutRepository aboutRepository,
        IFileService fileService,
        IHttpContextAccessor httpContextAccessor,
        IMapper mapper)
    {
        _aboutRepository = aboutRepository;
        _fileService = fileService;
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
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

        var about = _mapper.Map<About>(dto);
        about.Profile = imagePath;
        about.UserId = userId;

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

        var userAbouts = abouts.Where(x => x.UserId == userId).ToList();

        return _mapper.Map<List<AboutDto>>(userAbouts);
    }

    public async Task<AboutDto> GetById(int id)
    {
        var userId = GetUserId();

        var about = await _aboutRepository.GetById(id);

        if (about == null || about.UserId != userId)
            throw new Exception("Unauthorized access");

        return _mapper.Map<AboutDto>(about);
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
        about.SubTitle = input.SubTitle;

        await _aboutRepository.Update(about);
    }
}