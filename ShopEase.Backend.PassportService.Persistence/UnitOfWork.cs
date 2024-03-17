using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShopEase.Backend.Common.Domain;
using ShopEase.Backend.Common.Domain.Primitives;

namespace ShopEase.Backend.PassportService.Persistence
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext) => _appDbContext = appDbContext;

        /// <summary>
        /// Custom SaveChanges method on top of the SaveChanges of EFCore
        /// Handles Update of Auditable Entites before saving changes to DB
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAuditableEntities();

            return _appDbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// To set Auditable Properties of the Auditable Enitites
        /// Using ChangeTracker of EF Core
        /// </summary>
        private void UpdateAuditableEntities()
        {
            IEnumerable<EntityEntry<IAudit>> entities = _appDbContext.ChangeTracker.Entries<IAudit>();

            foreach(EntityEntry<IAudit> entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    entity
                        .Property(x => x.CreatedOnUtc)
                        .CurrentValue = DateTime.UtcNow;

                    entity
                        .Property(x => x.RowStatus)
                        .CurrentValue = true;
                }

                if (entity.State == EntityState.Modified)
                {
                    entity
                        .Property(x => x.UpdatedOnUtc)
                        .CurrentValue = DateTime.UtcNow;
                }
            }
        }
    }
}
