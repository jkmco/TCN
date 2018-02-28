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
        Task<List<Transaction>> GetAllTransactionAsync();
        Task<List<TransactionCoin>> GetAllCoinAsync();
        Task<List<TransactionFx>> GetAllFxAsync();
    }
}