using ShopEase.Backend.PassportService.Core.Entities;

namespace ShopEase.Backend.PassportService.Core.RepositoryAbstrations
{
    public interface IUserCredentialsRepository
    {
        Task<UserCredentials?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

        void Add(UserCredentials userCredentials);

        void Update(UserCredentials userCredentials);

        void Delete(UserCredentials userCredentials);
    }
}
