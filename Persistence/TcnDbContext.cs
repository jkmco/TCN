using System;
using System.Threading;
using System.Threading.Tasks;
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
            // shadow properties
            modelBuilder.Entity<Transaction>().Property<bool>("IsDeleted");
            modelBuilder.Entity<Transaction>().Property<DateTime>("DeletedAt");
            modelBuilder.Entity<Transaction>().Property<DateTime>("CreatedAt");
            modelBuilder.Entity<Transaction>().Property<DateTime>("LastUpdatedAt");

            // fluent api
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

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        
        private void OnBeforeSaving()
        {
            foreach (var entry in ChangeTracker.Entries<Transaction>())
            {
                var now = DateTime.UtcNow;
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues["LastUpdatedAt"] = now;
                        break;
                    
                    case EntityState.Added:
                        entry.CurrentValues["IsDeleted"] = false;
                        entry.CurrentValues["CreatedAt"] = now;
                        entry.CurrentValues["LastUpdatedAt"] = now;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["IsDeleted"] = true;
                        break;
                }
            }
        }
    }
}