using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Interfaces
{
    public interface ITaskRepository
    {
        Task<TaskItem?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<IEnumerable<TaskItem>> GetAllAsync(CancellationToken ct = default);

        Task AddAsync(TaskItem task, CancellationToken ct = default);
        void Update(TaskItem task);
        void Delete(TaskItem task);
    }
}
