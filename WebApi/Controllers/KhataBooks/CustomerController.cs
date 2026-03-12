using Application.Customers;
using Application.Customers.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerApplication _customerApplication;

        public CustomerController(ICustomerApplication customerApplication)
        {
            _customerApplication = customerApplication;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCustomerDto input)
        {
            try
            {
                var result = await _customerApplication.Create(input);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var customer = await _customerApplication.GetById(id);
                if (customer == null)
                    return NotFound(new { error = "Customer not found" });

                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var customers = await _customerApplication.GetAll();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] CreateCustomerDto input)
        {
            try
            {
                await _customerApplication.Update(id, input);
                return Ok(new { message = "Customer updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _customerApplication.Delete(id);
                return Ok(new { message = "Customer deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("{id}/block")]
        public async Task<IActionResult> BlockCustomer(int id)
        {
            try
            {
                var result = await _customerApplication.BlockCustomer(id);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("send-reminder")]
        public async Task<IActionResult> SendReminder()
        {
            try
            {
                var result = await _customerApplication.SendReminder();
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}