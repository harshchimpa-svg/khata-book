using Application.Abouts;
using Application.Abouts.Dto;
using Microsoft.AspNetCore.Authorization;
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
        
        [Authorize(Roles =  "Admin")]
        [HttpPost]
        public async Task Create([FromForm] CreateAboutDto input)
        {
            await _aboutApplication.Create(input);
        }

        [Authorize(Roles =  "Admin,Employee")]
        [HttpGet("{id}")]
        public async Task<AboutDto> GetById(int id)
        {
            return await _aboutApplication.GetById(id);
        }

        [Authorize(Roles =  "Admin,Employee")]
        [HttpGet]
        public async Task<List<AboutDto>> GetAll()
        {
            return await _aboutApplication.GetAll();
        }

        [Authorize(Roles =  "Admin")]
        [HttpPut("{id}")]
        public async Task Update(int id, [FromForm] CreateAboutDto input)
        {
            await _aboutApplication.Update(id, input);
        }

        [Authorize(Roles =  "Admin")]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _aboutApplication.Delete(id);
        }
    }
}