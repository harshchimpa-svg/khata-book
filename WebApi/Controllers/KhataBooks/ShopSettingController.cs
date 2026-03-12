using Application.ShopSettings;
using Application.ShopSettings.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopSettingController : ControllerBase
    {
        private readonly IShopSettingApplication _shopSettingApplication;

        public ShopSettingController(IShopSettingApplication shopSettingApplication)
        {
            _shopSettingApplication = shopSettingApplication;
        }

        [Authorize(Roles =  "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateShopSettingDto input)
        {
            var result = await _shopSettingApplication.Create(input);
            return Ok(result);
        }

        [Authorize(Roles =  "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var shopSetting = await _shopSettingApplication.GetById(id);
            if (shopSetting == null)
                return NotFound("Shop Setting not found");

            return Ok(shopSetting);
        }

        [Authorize(Roles =  "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _shopSettingApplication.GetAll();
            return Ok(list);
        }

        [Authorize(Roles =  "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] CreateShopSettingDto input)
        {
            await _shopSettingApplication.Update(id, input);
            return Ok("Shop Setting updated successfully");
        }

        [Authorize(Roles =  "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _shopSettingApplication.Delete(id);
            return Ok("Shop Setting deleted successfully");
        }
    }
}