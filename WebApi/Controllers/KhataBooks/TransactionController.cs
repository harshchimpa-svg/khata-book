using Application.Transactions;
using Application.Transactions.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionApplication _transactionApplication;

        public TransactionController(ITransactionApplication transactionApplication)
        {
            _transactionApplication = transactionApplication;
        }

        [Authorize(Roles = "Admin,Employee")]
        [HttpPost]
        public async Task<string> Create(CreateTransactionDto input)
        {
            return await _transactionApplication.Create(input);
        }

        [Authorize(Roles = "Admin,Employee")]
        [HttpGet("{id}")]
        public async Task<TransactionDto> GetById(int id)
        {
            return await _transactionApplication.GetById(id);
        }

        [Authorize(Roles = "Admin,Employee")]
        [HttpGet]
        public async Task<List<TransactionDto>> GetAll()
        {
            return await _transactionApplication.GetAll();
        }

        [Authorize(Roles = "Admin,Employee")]
        [HttpPut("{id}")]
        public async Task Update(int id, CreateTransactionDto input)
        {
            await _transactionApplication.Update(id, input);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _transactionApplication.Delete(id);
        }
    }
}