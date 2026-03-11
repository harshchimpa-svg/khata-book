using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.ShopSettings;

public class ShopSettingRepository:IShopSettingRepository
{
    private readonly DataContext _context;

    public ShopSettingRepository(DataContext context)
    {   
        _context = context;
    }

    public async Task Delete(int id)    
    {
        var shopsettings = await _context.ShopSettings.FindAsync(id);
        _context.ShopSettings.Remove(shopsettings);
        await _context.SaveChangesAsync();  
    }
    public async Task<List<ShopSetting>> GetAll()
    {
        var shopsettings = await _context.ShopSettings.ToListAsync();
        return shopsettings;
    }

    public async Task<ShopSetting> GetById(int id)
    {
        return await _context.ShopSettings.FindAsync(id);
    }
    public async Task<ShopSetting> Create(ShopSetting shopsettings)
    {
        await _context.ShopSettings.AddAsync(shopsettings);
        await _context.SaveChangesAsync();

        return shopsettings;
    }

    public async Task Update(ShopSetting shopsettings)
    {
        _context.ShopSettings.Update(shopsettings);
        await _context.SaveChangesAsync();
    }
}