using Application.ShopSettings.Dto;

namespace Application.ShopSettings;

public interface IShopSettingApplication
{
    Task<string> Create(CreateShopSettingDto dto);
    Task Delete(int id);
    Task<List<ShopSettingsDto>> GetAll();
    Task<ShopSettingsDto> GetById(int id);
    Task Update(int Id, CreateShopSettingDto update);
}