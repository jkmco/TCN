using Microsoft.EntityFrameworkCore;
using TCN.Models;

namespace TCN.Persistence
{
    public class TcnDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionCoin> TransactionCoins { get; set; }
        public DbSet<TransactionFx> TransactionFx { get; set; }
        
        public TcnDbContext(DbContextOptions<TcnDbContext> options)
            : base(options)
        {
        }
    }
}