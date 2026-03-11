using Domain;

namespace Data.ShopSettings;

public interface IShopSettingRepository
{
    Task Delete(int id);
    Task<ShopSetting> GetById(int id);
    Task Update(ShopSetting shopsetting);
    Task<List<ShopSetting>> GetAll();
    Task<ShopSetting> Create(ShopSetting shopsetting);
}