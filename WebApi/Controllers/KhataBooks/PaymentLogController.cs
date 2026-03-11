using Microsoft.AspNetCore.Mvc;
using Application.PaymentLogs;
using Application.PaymentLogs.Dto;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentLogController : ControllerBase
    {
        private readonly IPaymentLogApplication _paymentLogApplication;

        public PaymentLogController(IPaymentLogApplication paymentLogApplication)
        {
            _paymentLogApplication = paymentLogApplication;
        }

        [HttpGet]
        public async Task<ActionResult<List<PaymentLogDto>>> GetAll()
        {
            var paymentLogs = await _paymentLogApplication.GetAll();
            return Ok(paymentLogs);
        }
    }
}