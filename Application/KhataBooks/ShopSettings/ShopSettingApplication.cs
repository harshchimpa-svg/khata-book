using Application.ShopSettings.Dto;
using Data.ShopSettings;
using Domain;

namespace Application.ShopSettings;

public class ShopSettingApplication : IShopSettingApplication
{
    private readonly IShopSettingRepository _shopSettingRepository;

    public ShopSettingApplication(IShopSettingRepository shopSettingRepository)
    {
        _shopSettingRepository = shopSettingRepository;
    }

    public async Task<string> Create(CreateShopSettingDto dto)
    {
        var shopSetting = new ShopSetting
        {
            ShopeName = dto.ShopeName,
            OnerName = dto.OnerName,
            PhoneNo = dto.PhoneNo,
            Email = dto.Email,
            GstNumber = dto.GstNumber,
            EmployeeId = dto.EmployeeId,
            UserId = dto.UserId
        };

        await _shopSettingRepository.Create(shopSetting);

        return "Shop Setting Created";
    }

    public async Task Delete(int id)
    {
        await _shopSettingRepository.Delete(id);
    }

    public async Task<List<ShopSettingsDto>> GetAll()
    {
        var list = await _shopSettingRepository.GetAll();

        return list.Select(x => new ShopSettingsDto
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
        var entity = await _shopSettingRepository.GetById(id);

        if (entity == null)
            return null;

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
        var entity = await _shopSettingRepository.GetById(id);

        if (entity == null)
            throw new Exception("Shop Setting not found");

        entity.ShopeName = dto.ShopeName;
        entity.OnerName = dto.OnerName;
        entity.PhoneNo = dto.PhoneNo;
        entity.Email = dto.Email;
        entity.GstNumber = dto.GstNumber;
        entity.EmployeeId = dto.EmployeeId;
        entity.UserId = dto.UserId;

        await _shopSettingRepository.Update(entity);
    }
}