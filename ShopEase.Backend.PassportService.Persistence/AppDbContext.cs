using Microsoft.EntityFrameworkCore;

namespace ShopEase.Backend.PassportService.Persistence
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) 
            : base(dbContextOptions) 
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
;    }
}
