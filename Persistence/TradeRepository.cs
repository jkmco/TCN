using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TCN.Extensions;
using TCN.Models;

namespace TCN.Persistence
{
    public class TradeRepository : ITradeRepository
    {
        private readonly TcnDbContext context;
        public TradeRepository(TcnDbContext context)
        {
            this.context = context;
        }

        public void Add(Trade trade)
        {
            context.Trades.Add(trade);
        }
        public void Remove(Trade trade)
        {
            context.Trades.Remove(trade);
        }

        public async Task<Trade> GetTradeAsync(int id, bool includeRelated = true)
        {
            if(!includeRelated)
                return await context.Trades.FindAsync(id);

            return await context.Trades
                    .Include(t => t.User)
                    .Include(t => t.Coin)
                    .Include(t => t.Fx)
                    .SingleOrDefaultAsync(t => t.Id == id);
        }
        public async Task<IEnumerable<Trade>> GetAllTradeAsync(TradeQuery queryObj)
        {
            var query = context.Trades
                    .Include(t => t.User)
                    .Include(t => t.Coin)
                    .Include(t => t.Fx)
                    .AsQueryable();
            
            if(queryObj.TradeId.HasValue)
                query = query.Where(t => t.Id == queryObj.TradeId);

            if(queryObj.CoinId.HasValue)
                query = query.Where(t => t.TradeCoinId == queryObj.CoinId);

            var columnsMap = new Dictionary<string, Expression<Func<Trade, object>>>()
            {
                ["user"] = t => t.User.Name,
                ["coin"] = t => t.Coin.Name,
                ["fx"] = t => t.Fx.Name,
                ["price"] = t => t.Price
            };

            query = query.ApplyOrdering(queryObj, columnsMap);
            query = query.ApplyPaging(queryObj);
            
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TradeCoin>> GetAllCoinAsync()
        {
            return await context.TradeCoins.ToListAsync();
        }
        public async Task<IEnumerable<TradeFx>> GetAllFxAsync()
        {
            return await context.TradeFxs.ToListAsync();
        }
    }
}