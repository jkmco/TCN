using System.Collections.Generic;
using System.Threading.Tasks;
using TCN.Models;

namespace TCN.Persistence
{
    public interface ITradeRepository
    {
        void Add(Trade trade);
        void Remove(Trade trade);
        Task<Trade> GetTradeAsync(int id, bool includeRelated = true);
        Task<IEnumerable<Trade>> GetAllTradeAsync(TradeQuery filter);
        Task<IEnumerable<TradeCoin>> GetAllCoinAsync();
        Task<IEnumerable<TradeFx>> GetAllFxAsync();
    }
}