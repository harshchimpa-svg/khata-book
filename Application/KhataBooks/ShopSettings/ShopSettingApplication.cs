using System.Security.Claims;
using Application.ShopSettings.Dto;
using AutoMapper;
using Data.ShopSettings;
using Domain;
using Microsoft.AspNetCore.Http;

namespace Application.ShopSettings;

public class ShopSettingApplication : IShopSettingApplication
{
    private readonly IShopSettingRepository _shopSettingRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;

    public ShopSettingApplication(
        IShopSettingRepository shopSettingRepository,
        IHttpContextAccessor httpContextAccessor,
        IMapper mapper)
    {
        _shopSettingRepository = shopSettingRepository;
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

    public async Task<string> Create(CreateShopSettingDto dto)
    {
        var userId = GetUserId();

        var shopSetting = _mapper.Map<ShopSetting>(dto);
        shopSetting.UserId = userId;

        await _shopSettingRepository.Create(shopSetting);

        return "Shop Setting Created";
    }

    public async Task Delete(int id)
    {
        var userId = GetUserId();

        var entity = await _shopSettingRepository.GetById(id);

        if (entity == null || entity.UserId != userId)
            throw new Exception("Unauthorized access");

        await _shopSettingRepository.Delete(id);
    }

    public async Task<List<ShopSettingsDto>> GetAll()
    {
        var userId = GetUserId();

        var list = await _shopSettingRepository.GetAll();

        var userSettings = list.Where(x => x.UserId == userId).ToList();

        return _mapper.Map<List<ShopSettingsDto>>(userSettings);
    }

    public async Task<ShopSettingsDto> GetById(int id)
    {
        var userId = GetUserId();

        var entity = await _shopSettingRepository.GetById(id);

        if (entity == null || entity.UserId != userId)
            throw new Exception("Unauthorized access");

        return _mapper.Map<ShopSettingsDto>(entity);
    }

    public async Task Update(int id, CreateShopSettingDto dto)
    {
        var userId = GetUserId();

        var entity = await _shopSettingRepository.GetById(id);

        if (entity == null || entity.UserId != userId)
            throw new Exception("Unauthorized access");

        entity.ShopName = dto.ShopName;
        entity.OwnerName = dto.OwnerName;
        entity.PhoneNo = dto.PhoneNo;
        entity.Email = dto.Email;
        entity.GstNumber = dto.GstNumber;
        entity.EmployeeId = dto.EmployeeId;

        await _shopSettingRepository.Update(entity);
    }
}