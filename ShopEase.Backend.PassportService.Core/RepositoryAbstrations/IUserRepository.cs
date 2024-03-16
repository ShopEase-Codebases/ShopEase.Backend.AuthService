using ShopEase.Backend.PassportService.Core.Entities;

namespace ShopEase.Backend.PassportService.Core.RepositoryAbstrations
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<bool> IsEmailUniqueAsync(string Email, CancellationToken cancellationToken = default);

        void Add(User user);

        void Update(User user);

        void Delete(User user);
    }
}
