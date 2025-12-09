using System.Threading;
using System.Threading.Tasks;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IUserRepository Users { get; }
        public ITaskRepository Tasks { get; }

        public UnitOfWork(AppDbContext context, IUserRepository userRepository, ITaskRepository taskRepository)
        {
            _context = context;
            Users = userRepository;
            Tasks = taskRepository;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
