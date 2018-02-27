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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(eu => {
                eu.ToTable("Users");
                eu.Property(u => u.Name).HasColumnType("varchar(255)").IsRequired();
            });

            modelBuilder.Entity<Transaction>(et => {
                et.ToTable("Transactions");
                et.Property(t => t.Price).IsRequired();
                et.Property(t => t.MinLimit).IsRequired();
                et.Property(t => t.MaxLimit).IsRequired();
            });

            modelBuilder.Entity<TransactionCoin>(ec => {
                ec.ToTable("TransactionCoins");
                ec.Property(c => c.Name).HasColumnType("varchar(20)").IsRequired();
            });

             modelBuilder.Entity<TransactionFx>(ef => {
                ef.ToTable("TransactionFxs");
                ef.Property(f => f.Name).HasColumnType("varchar(3)").IsRequired();
            });
        }
    }
}