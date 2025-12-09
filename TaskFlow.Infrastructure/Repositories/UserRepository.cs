using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Entities;
using TaskFlow.Infrastructure.Data;

namespace TaskFlow.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
            await _context.Users.FindAsync(new object[] { id }, ct);

        public async Task<User?> GetByEmailAsync(string email, CancellationToken ct = default) =>
            await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email, ct);

        public async Task AddAsync(User user, CancellationToken ct = default) =>
            await _context.Users.AddAsync(user, ct);

        public void Update(User user) => _context.Users.Update(user);

        public void Delete(User user) => _context.Users.Remove(user);

        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken ct = default) =>
            await _context.Users.AsNoTracking().ToListAsync(ct);
    }
}
