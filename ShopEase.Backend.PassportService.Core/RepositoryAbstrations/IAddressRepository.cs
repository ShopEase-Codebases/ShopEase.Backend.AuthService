using ShopEase.Backend.PassportService.Core.Entities;

namespace ShopEase.Backend.PassportService.Core.RepositoryAbstrations
{
    public interface IAddressRepository
    {
        Task<Address> GetById(Guid id, CancellationToken cancellationToken = default);

        Task<List<Address>> GetAllByUserId(Guid userId, CancellationToken cancellationToken = default);

        void Add(Address address);

        void Update(Address address);

        void Delete(Address address);
    }
}
