using ShopEase.Backend.PassportService.Core.Entities;
using ShopEase.Backend.PassportService.Core.RepositoryAbstrations;

namespace ShopEase.Backend.PassportService.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsEmailUniqueAsync(string Email, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
