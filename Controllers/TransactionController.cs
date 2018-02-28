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
        private readonly TcnDbContext context;
        private readonly IMapper mapper;
        public TransactionController(TcnDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionResource transactionResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var transaction = mapper.Map<CreateTransactionResource, Transaction>(transactionResource);
            
            context.Transactions.Add(transaction);
            await context.SaveChangesAsync();

            var result = mapper.Map<Transaction, CreateTransactionResource>(transaction);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(int id, [FromBody] CreateTransactionResource transactionResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var transaction = await context.Transactions.FindAsync(id);
            
            if (transaction == null)
                return NotFound();

            mapper.Map<CreateTransactionResource, Transaction>(transactionResource, transaction);
            
            await context.SaveChangesAsync();

            var result = mapper.Map<Transaction, CreateTransactionResource>(transaction);

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var transaction = await context.Transactions.FindAsync(id);

            if (transaction == null)
                return NotFound();

            context.Remove(transaction);
            await context.SaveChangesAsync();   

            return Ok(id); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransaction(int id)
        {
            var transaction = await context.Transactions.FindAsync(id);

            if (transaction == null)
                return NotFound();

            var result = mapper.Map<Transaction,CreateTransactionResource>(transaction);

            return Ok(result); 
        }
        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            var transactions = await context.Transactions.ToListAsync();

            if (transactions == null)
                return NotFound();

            var result = mapper.Map<List<Transaction>, List<CreateTransactionResource>>(transactions);

            return Ok(result);
        }

        [HttpGet("coins")]
        public async Task<IActionResult> GetTransactionCoins()
        {
            var coins = await context.TransactionCoins.ToListAsync();

            if (coins == null)
                return NotFound();

            var result = mapper.Map<List<TransactionCoin>, List<KeyValuePairResource>>(coins);

            return Ok(result);
        }

        [HttpGet("fxs")]
        public async Task<IActionResult> GetTransactionFxs()
        {
            var fxs = await context.TransactionFxs.ToListAsync();

            if (fxs == null)
                return NotFound();

            var result = mapper.Map<List<TransactionFx>, List<KeyValuePairResource>>(fxs);

            return Ok(result);
        }
        

    }
}