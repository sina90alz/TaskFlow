using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Interfaces
{
    public interface IUserRepository
    {
        // Get a user by Id
        Task<User?> GetByIdAsync(Guid id, CancellationToken ct = default);

        // Get a user by Email
        Task<User?> GetByEmailAsync(string email, CancellationToken ct = default);

        // Get all users (read-only)
        Task<IEnumerable<User>> GetAllAsync(CancellationToken ct = default);

        // Add a new user (does not save changes)
        Task AddAsync(User user, CancellationToken ct = default);

        // Update an existing user (does not save changes)
        void Update(User user);

        // Delete an existing user (does not save changes)
        void Delete(User user);
    }
}
