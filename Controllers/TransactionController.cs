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
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionResource transactionResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var transaction = mapper.Map<TransactionResource, Transaction>(transactionResource);
            
            context.Transactions.Add(transaction);
            await context.SaveChangesAsync();

            var result = mapper.Map<Transaction, TransactionResource>(transaction);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(int id, [FromBody] TransactionResource transactionResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var transaction = await context.Transactions.FindAsync(id);
            
            if (transaction == null)
                return NotFound();

            mapper.Map<TransactionResource, Transaction>(transactionResource, transaction);
            
            await context.SaveChangesAsync();

            var result = mapper.Map<Transaction, TransactionResource>(transaction);

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

        [HttpGet]
        public async Task<IEnumerable<TransactionResource>> GetTransactions()
        {
            var transactions = await context.Transactions.ToListAsync();
            return mapper.Map<List<Transaction>, List<TransactionResource>>(transactions);   
        }

    }
}