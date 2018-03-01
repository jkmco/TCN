using System.Threading.Tasks;

namespace TCN.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TcnDbContext context;
        public UnitOfWork(TcnDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}