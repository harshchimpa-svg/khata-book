using System.Security.Claims;
using Application.ShopSettings.Dto;
using Data.ShopSettings;
using Domain;
using Microsoft.AspNetCore.Http;

namespace Application.ShopSettings;

public class ShopSettingApplication : IShopSettingApplication
{
    private readonly IShopSettingRepository _shopSettingRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ShopSettingApplication(
        IShopSettingRepository shopSettingRepository,
        IHttpContextAccessor httpContextAccessor)
    {
        _shopSettingRepository = shopSettingRepository;
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

    public async Task<string> Create(CreateShopSettingDto dto)
    {
        var userId = GetUserId();

        var shopSetting = new ShopSetting
        {
            ShopeName = dto.ShopeName,
            OnerName = dto.OnerName,
            PhoneNo = dto.PhoneNo,
            Email = dto.Email,
            GstNumber = dto.GstNumber,
            EmployeeId = dto.EmployeeId,
            UserId = userId
        };

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

        return list
            .Where(x => x.UserId == userId)
            .Select(x => new ShopSettingsDto
            {
                Id = x.Id,
                ShopeName = x.ShopeName,
                OnerName = x.OnerName,
                PhoneNo = x.PhoneNo,
                Email = x.Email,
                GstNumber = x.GstNumber,
                EmployeeId = x.EmployeeId,
                UserId = x.UserId
            }).ToList();
    }

    public async Task<ShopSettingsDto> GetById(int id)
    {
        var userId = GetUserId();

        var entity = await _shopSettingRepository.GetById(id);

        if (entity == null || entity.UserId != userId)
            throw new Exception("Unauthorized access");

        return new ShopSettingsDto
        {
            Id = entity.Id,
            ShopeName = entity.ShopeName,
            OnerName = entity.OnerName,
            PhoneNo = entity.PhoneNo,
            Email = entity.Email,
            GstNumber = entity.GstNumber,
            EmployeeId = entity.EmployeeId,
            UserId = entity.UserId
        };
    }

    public async Task Update(int id, CreateShopSettingDto dto)
    {
        var userId = GetUserId();

        var entity = await _shopSettingRepository.GetById(id);

        if (entity == null || entity.UserId != userId)
            throw new Exception("Unauthorized access");

        entity.ShopeName = dto.ShopeName;
        entity.OnerName = dto.OnerName;
        entity.PhoneNo = dto.PhoneNo;
        entity.Email = dto.Email;
        entity.GstNumber = dto.GstNumber;
        entity.EmployeeId = dto.EmployeeId;

        await _shopSettingRepository.Update(entity);
    }
}