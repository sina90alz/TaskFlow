using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Entities;
using TaskFlow.Infrastructure.Data;

namespace TaskFlow.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        // Get a task by Id
        public async Task<TaskItem?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
            await _context.Tasks.FindAsync(new object[] { id }, ct);

        // Get all tasks (read-only)
        public async Task<IEnumerable<TaskItem>> GetAllAsync(CancellationToken ct = default) =>
            await _context.Tasks
                .AsNoTracking()
                .ToListAsync(ct);

        // Add a new task (does not call SaveChanges)
        public async Task AddAsync(TaskItem task, CancellationToken ct = default) =>
            await _context.Tasks.AddAsync(task, ct);

        // Update an existing task
        public void Update(TaskItem task) =>
            _context.Tasks.Update(task);

        // Delete a task by entity
        public void Delete(TaskItem task) =>
            _context.Tasks.Remove(task);
    }
}
