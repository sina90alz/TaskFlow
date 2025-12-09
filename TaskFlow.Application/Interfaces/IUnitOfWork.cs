using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskFlow.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ITaskRepository Tasks { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
