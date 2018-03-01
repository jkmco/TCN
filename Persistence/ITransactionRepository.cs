using System.Collections.Generic;
using System.Threading.Tasks;
using TCN.Models;

namespace TCN.Persistence
{
    public interface ITransactionRepository
    {
        void Add(Transaction transaction);
        void Remove(Transaction transaction);
        Task<Transaction> GetTransactionAsync(int id, bool includeRelated = true);
        Task<IEnumerable<Transaction>> GetAllTransactionAsync(Filter filter);
        Task<IEnumerable<TransactionCoin>> GetAllCoinAsync();
        Task<IEnumerable<TransactionFx>> GetAllFxAsync();
    }
}