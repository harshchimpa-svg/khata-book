using Application.Abouts.Dto;
using Data.Aboutes;
using Data.Services;
using Domain;

namespace Application.Abouts;

public class AboutApplication : IAboutApplication
{
    private readonly IAboutRepository _aboutRepository;
    private readonly IFileService _fileService;

    public AboutApplication(IAboutRepository aboutRepository, IFileService fileService)
    {
        _aboutRepository = aboutRepository;
        _fileService = fileService;
    }

    public async Task<string> Create(CreateAboutDto dto)
    {
        var imagePath = await _fileService.UploadImage(dto.Profile, "about");

        var about = new About
        {
            Name = dto.Name,
            Profile = imagePath,
            SubTitel = dto.SubTitel
        };

        await _aboutRepository.Create(about);

        return "About Created";
    }

    public async Task Delete(int id)
    {
        await _aboutRepository.Delete(id);
    }

    public async Task<List<AboutDto>> GetAll()
    {
        var abouts = await _aboutRepository.GetAll();

        return abouts.Select(x => new AboutDto
        {
            Id = x.Id,
            Name = x.Name,
            Profile = x.Profile,
            SubTitel = x.SubTitel
        }).ToList();
    }

    public async Task<AboutDto> GetById(int id)
    {
        var about = await _aboutRepository.GetById(id);

        if (about == null)
            return null;

        return new AboutDto
        {
            Id = about.Id,
            Name = about.Name,
            Profile = about.Profile,
            SubTitel = about.SubTitel
        };
    }

    public async Task Update(int id, CreateAboutDto input)
    {
        var about = await _aboutRepository.GetById(id);

        if (about == null)
            throw new Exception("About not found");

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