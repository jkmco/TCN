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
        public DbSet<Trade> Trades { get; set; }
        public DbSet<TradeCoin> TradeCoins { get; set; }
        public DbSet<TradeFx> TradeFxs { get; set; }
        public DbSet<Photo> Photos { get; set; }
        
        public TcnDbContext(DbContextOptions<TcnDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // shadow properties
            modelBuilder.Entity<Trade>().Property<bool>("IsDeleted");
            modelBuilder.Entity<Trade>().Property<DateTime>("DeletedAt");
            modelBuilder.Entity<Trade>().Property<DateTime>("CreatedAt");
            modelBuilder.Entity<Trade>().Property<DateTime>("LastUpdatedAt");

            modelBuilder.Entity<Trade>()
                .HasQueryFilter(trade => EF.Property<bool>(trade, "IsDeleted") == false);
    
            // fluent api
            modelBuilder.Entity<User>(eu => {
                eu.ToTable("Users");
                eu.Property(u => u.Name).HasColumnType("varchar(255)").IsRequired();
            });

            modelBuilder.Entity<Trade>(et => {
                et.ToTable("Trades");
                et.Property(t => t.Price).IsRequired();
                et.Property(t => t.MinLimit).IsRequired();
                et.Property(t => t.MaxLimit).IsRequired();
            });

            modelBuilder.Entity<TradeCoin>(ec => {
                ec.ToTable("TradeCoins");
                ec.Property(c => c.Name).HasColumnType("varchar(20)").IsRequired();
            });

             modelBuilder.Entity<TradeFx>(ef => {
                ef.ToTable("TradeFxs");
                ef.Property(f => f.Name).HasColumnType("varchar(3)").IsRequired();
            });   
            
            modelBuilder.Entity<Photo>(p => {
                p.ToTable("Photos");
                p.Property(c => c.FileName).HasColumnType("varchar(255)").IsRequired();
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
            foreach (var entry in ChangeTracker.Entries<Trade>())
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
                        entry.CurrentValues["DeletedAt"] = now;                        
                        break;
                }
            }
        }
    }
}