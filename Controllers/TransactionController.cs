using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCN.Controllers.Resources;
using TCN.Models;
using TCN.Persistence;

namespace TCN.Controllers
{
    [Route("/api/transactions")]
    public class TransactionController : Controller
    {
        private readonly IMapper mapper;
        private readonly ITransactionRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public TransactionController(IMapper mapper, ITransactionRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] SaveTransactionResource transactionResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var transaction = mapper.Map<SaveTransactionResource, Transaction>(transactionResource);

            repository.Add(transaction);
            await unitOfWork.CompleteAsync();

            var result = mapper.Map<Transaction, SaveTransactionResource>(transaction);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(int id, [FromBody] SaveTransactionResource transactionResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var transaction = await repository.GetTransactionAsync(id);

            if (transaction == null)
                return NotFound();

            mapper.Map<SaveTransactionResource, Transaction>(transactionResource, transaction);

            await unitOfWork.CompleteAsync();

            var result = mapper.Map<Transaction, LoadTransactionResource>(transaction);

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var transaction = await repository.GetTransactionAsync(id, includeRelated: false);

            if (transaction == null)
                return NotFound();

            repository.Remove(transaction);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransaction(int id)
        {
            var transaction = await repository.GetTransactionAsync(id);

            if (transaction == null)
                return NotFound();

            var result = mapper.Map<Transaction, LoadTransactionResource>(transaction);

            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            var transactions = await repository.GetAllTransactionAsync();

            if (transactions == null)
                return NotFound();

            var result = mapper.Map<List<Transaction>, List<LoadTransactionResource>>(transactions);

            return Ok(result);
        }

        [HttpGet("coins")]
        public async Task<IActionResult> GetTransactionCoins()
        {
            var coins = await repository.GetAllCoinAsync();

            if (coins == null)
                return NotFound();

            var result = mapper.Map<List<TransactionCoin>, List<KeyValuePairResource>>(coins);

            return Ok(result);
        }

        [HttpGet("fxs")]
        public async Task<IActionResult> GetTransactionFxs()
        {
            var fxs = await repository.GetAllFxAsync();

            if (fxs == null)
                return NotFound();

            var result = mapper.Map<List<TransactionFx>, List<KeyValuePairResource>>(fxs);

            return Ok(result);
        }


    }
}