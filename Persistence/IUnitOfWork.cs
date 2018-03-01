using System.Threading.Tasks;

namespace TCN.Persistence
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}