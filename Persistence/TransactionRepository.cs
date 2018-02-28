using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TCN.Models;

namespace TCN.Persistence
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly TcnDbContext context;
        public TransactionRepository(TcnDbContext context)
        {
            this.context = context;
        }

        public void Add(Transaction transaction)
        {
            context.Transactions.Add(transaction);
        }
        public void Remove(Transaction transaction)
        {
            context.Transactions.Remove(transaction);
        }

        public async Task<Transaction> GetTransactionAsync(int id, bool includeRelated = true)
        {
            if(!includeRelated)
                return await context.Transactions.FindAsync(id);

            return await context.Transactions
                    .Include(t => t.User)
                    .Include(t => t.Coin)
                    .Include(t => t.Fx)
                    .SingleOrDefaultAsync(t => t.Id == id);
        }
        public async Task<List<Transaction>> GetAllTransactionAsync()
        {
            return await context.Transactions
                    .Include(t => t.User)
                    .Include(t => t.Coin)
                    .Include(t => t.Fx)
                    .ToListAsync();
        }
        public async Task<List<TransactionCoin>> GetAllCoinAsync()
        {
            return await context.TransactionCoins.ToListAsync();
        }
        public async Task<List<TransactionFx>> GetAllFxAsync()
        {
            return await context.TransactionFxs.ToListAsync();
        }
    }
}