using ShopEase.Backend.PassportService.Core.Entities;
using ShopEase.Backend.PassportService.Core.ValueObjects;

namespace ShopEase.Backend.PassportService.Core.RepositoryAbstrations
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<User?> GetByIdAsyncWithCredentials(Guid id, CancellationToken cancellationToken = default);

        Task<User?> GetByIdAsyncWithAddress(Guid id, CancellationToken cancellationToken = default);

        Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken = default);

        void Add(User user);

        void Update(User user);

        void Delete(User user);
    }
}
