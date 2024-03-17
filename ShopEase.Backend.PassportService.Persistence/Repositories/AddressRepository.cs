using Microsoft.EntityFrameworkCore;
using ShopEase.Backend.PassportService.Core.Entities;
using ShopEase.Backend.PassportService.Core.RepositoryAbstrations;

namespace ShopEase.Backend.PassportService.Persistence.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _appDbContext;

        public AddressRepository(AppDbContext appDbContext) 
            => _appDbContext = appDbContext;

        public async Task<Address?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _appDbContext
                            .Set<Address>()
                            .Where(address => address.Id == id)
                            .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<Address>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await _appDbContext
                            .Set<Address>()
                            .Where(address => address.UserId == userId)
                            .OrderBy(address => address.Id)
                            .ToListAsync(cancellationToken);
        }

        public async Task<Address?> GetDefaultByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await _appDbContext
                            .Set<Address>()
                            .Where(address => 
                                address.UserId == userId && 
                                address.IsDefault)
                            .FirstOrDefaultAsync(cancellationToken);
        }

        public void Add(Address address)
        {
            _appDbContext.Set<Address>().Add(address);
        }

        public void Update(Address address)
        {
            _appDbContext.Set<Address>().Update(address);
        }

        public void Delete(Address address)
        {
            _appDbContext.Set<Address>().Remove(address);
        }
    }
}
