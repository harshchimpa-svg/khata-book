using Application.Abouts;
using Application.Abouts.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutApplication _aboutApplication;

        public AboutController(IAboutApplication aboutApplication)
        {
            _aboutApplication = aboutApplication;
        }

        [HttpPost]
        public async Task Create([FromForm] CreateAboutDto input)
        {
            await _aboutApplication.Create(input);
        }

        [HttpGet("{id}")]
        public async Task<AboutDto> GetById(int id)
        {
            return await _aboutApplication.GetById(id);
        }

        [HttpGet]
        public async Task<List<AboutDto>> GetAll()
        {
            return await _aboutApplication.GetAll();
        }

        [HttpPut("{id}")]
        public async Task Update(int id, [FromForm] CreateAboutDto input)
        {
            await _aboutApplication.Update(id, input);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _aboutApplication.Delete(id);
        }
    }
}