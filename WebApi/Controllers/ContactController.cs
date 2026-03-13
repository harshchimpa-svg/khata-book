using Application.Contacts;
using Application.Contacts.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ManjeetFigma.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactApplication _contactApp;

        public ContactController(IContactApplication contactApp)
        {
            _contactApp = contactApp;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateContactDto dto)
        {
            var result = await _contactApp.Create(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _contactApp.GetAll();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _contactApp.GetById(id);
            if (contact == null)
                return NotFound("Contact not found");

            return Ok(contact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateContactDto dto)
        {
            await _contactApp.Update(id, dto);
            return Ok("Contact updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _contactApp.Delete(id);
            return Ok("Contact deleted");
        }
    }
}