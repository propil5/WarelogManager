using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.IO;
using WarelogManager.Model.DataTransfer.Warehouse;
using WarelogManager.Model.DataTransfer.Common;

namespace WarelogManager.Model.Mapping
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {

        }

        public virtual DbSet<ProductDto> Products { get; set; }
        public virtual DbSet<CompanyDto> Companies { get; set; }
        public virtual DbSet<PalletDto> Pallets { get; set; }
        public virtual DbSet<AddressDto> Addresses { get; set; }
        public virtual DbSet<PositionDto> Positions { get; set; }
        public virtual DbSet<PlantDto> Plants { get; set; }
        public virtual DbSet<RackDto> Racks { get; set; }

        internal ApplicationDbContext CreateDbContext(object p)
        {
            throw new System.NotImplementedException();
        }

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(@Directory.GetCurrentDirectory() + "/../../src/Server/appsettings.json")
                    .Build();
                var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                builder.UseSqlServer(connectionString);
                return new ApplicationDbContext(builder.Options, new OperationalStoreOptionsMigrations());
            }
        }

        public class OperationalStoreOptionsMigrations : IOptions<OperationalStoreOptions>
        {
            public OperationalStoreOptions Value => new()
            {
                DeviceFlowCodes = new TableConfiguration("DeviceCodes"),
                EnableTokenCleanup = false,
                PersistedGrants = new TableConfiguration("PersistedGrants"),
                TokenCleanupBatchSize = 100,
                TokenCleanupInterval = 3600,
            };
        }
    }
}
