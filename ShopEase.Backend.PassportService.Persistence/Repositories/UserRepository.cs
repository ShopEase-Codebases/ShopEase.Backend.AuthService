using Microsoft.EntityFrameworkCore;
using ShopEase.Backend.PassportService.Application.Abstractions.Repositories;
using ShopEase.Backend.PassportService.Core.Aggregate;
using ShopEase.Backend.PassportService.Core.ValueObjects;

namespace ShopEase.Backend.PassportService.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext) => _appDbContext = appDbContext;

        public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _appDbContext
                            .Set<User>()
                            .Where(user => user.Id == id)
                            .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<User?> GetByIdAsyncWithCredentials(Guid id, CancellationToken cancellationToken = default)
        {
            return await _appDbContext
                            .Set<User>()
                            .Include(user => user.UserCredentials)
                            .Where(user => user.Id == id)
                            .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<User?> GetByIdAsyncWithAddress(Guid id, CancellationToken cancellationToken = default)
        {
            return await _appDbContext
                            .Set<User>()
                            .Include(user => user.Addresses)
                            .Where(user => user.Id == id)
                            .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken = default)
        {
            return !await _appDbContext
                            .Set<User>()
                            .AnyAsync(user => user.Email == email, cancellationToken);
        }

        public void Add(User user)
        {
            _appDbContext.Set<User>().Add(user);
        }

        public void Update(User user)
        {
            _appDbContext.Set<User>().Update(user);
        }

        public void Delete(User user)
        {
            _appDbContext.Set<User>().Remove(user);
        }
    }
}
