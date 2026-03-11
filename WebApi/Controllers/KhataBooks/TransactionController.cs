using Application.Transactions;
using Application.Transactions.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionApplication _transactionApplication;

        public TransactionController(ITransactionApplication transactionApplication)
        {
            _transactionApplication = transactionApplication;
        }

        [HttpPost]
        public async Task<string> Create(CreateTransactionDto input)
        {
            return await _transactionApplication.Create(input);
        }

        [HttpGet("{id}")]
        public async Task<TransactionDto> GetById(int id)
        {
            return await _transactionApplication.GetById(id);
        }

        [HttpGet]
        public async Task<List<TransactionDto>> GetAll()
        {
            return await _transactionApplication.GetAll();
        }

        [HttpPut("{id}")]
        public async Task Update(int id, CreateTransactionDto input)
        {
            await _transactionApplication.Update(id, input);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _transactionApplication.Delete(id);
        }
    }
}