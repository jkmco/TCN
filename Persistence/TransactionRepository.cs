using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public async Task<IEnumerable<Transaction>> GetAllTransactionAsync(TransactionQuery queryObj)
        {
            var query = context.Transactions
                    .Include(t => t.User)
                    .Include(t => t.Coin)
                    .Include(t => t.Fx)
                    .AsQueryable();
            
            if(queryObj.TransactionId.HasValue)
                query = query.Where(t => t.Id == queryObj.TransactionId);

            if(queryObj.CoinId.HasValue)
                query = query.Where(t => t.TransactionCoinId == queryObj.CoinId);

            var columnsMap = new Dictionary<string, Expression<Func<Transaction, object>>>()
            {
                ["user"] = t => t.User.Name,
                ["coin"] = t => t.Coin.Name,
                ["fx"] = t => t.Fx.Name,
                ["price"] = t => t.Price
            };

            if(queryObj.IsSortAscending)
                query = query.OrderBy(columnsMap[queryObj.SortBy]);
            else
                query = query.OrderByDescending(columnsMap[queryObj.SortBy]);
            
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<TransactionCoin>> GetAllCoinAsync()
        {
            return await context.TransactionCoins.ToListAsync();
        }
        public async Task<IEnumerable<TransactionFx>> GetAllFxAsync()
        {
            return await context.TransactionFxs.ToListAsync();
        }
    }
}