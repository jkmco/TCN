using Microsoft.EntityFrameworkCore;

namespace TCN.Persistence
{
    public class TcnDbContext : DbContext
    {
        public TcnDbContext(DbContextOptions<TcnDbContext> options)
            : base(options)
        {
        }
    }
}