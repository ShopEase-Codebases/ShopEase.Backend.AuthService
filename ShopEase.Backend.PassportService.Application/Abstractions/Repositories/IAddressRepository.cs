using ShopEase.Backend.PassportService.Core.Entities;

namespace ShopEase.Backend.PassportService.Application.Abstractions.Repositories
{
    public interface IAddressRepository
    {
        Task<Address?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<List<Address>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

        Task<Address?> GetDefaultByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

        void Add(Address address);

        void Update(Address address);

        void Delete(Address address);
    }
}
