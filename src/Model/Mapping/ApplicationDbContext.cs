using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.IO;
using WarelogManager.Model.DataTransfer.Warehouse;
using WarelogManager.Model.DataTransfer.Common;
using WarelogManager.Model.DataTransfer.Utilities;
using WarelogManager.Model.DataTransfer.Accounting;
using WarelogManager.Model.DataTransfer.Estimating;
using WarelogManager.Model.DataTransfer.Inbound;
using WarelogManager.Model.DataTransfer.Monitoring;
using WarelogManager.Model.DataTransfer.Payment;
using WarelogManager.Model.DataTransfer.Sales;

namespace WarelogManager.Model.Mapping
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {

        }

        //Accounting
        public virtual DbSet<AccountingBalance> AccountingBalances { get; set; }
        public virtual DbSet<BillingAccountDto> BillingAccounts { get; set; }
        public virtual DbSet<InvoiceDto> Invoices { get; set; }
        public virtual DbSet<InvoiceOrderDto> InvoiceOrders { get; set; }

        //Estimating
        public virtual DbSet<EstimateProductDto> EstimateProducts { get; set; }
        public virtual DbSet<EstimateStatusDto> EstimateStatuses { get; set; }

        //Inbound
        public virtual DbSet<SupplierDto> Suppliers { get; set; }
        public virtual DbSet<SupplyDto> Supplies { get; set; }
        public virtual DbSet<IncomingTransportDto> IncomingTransports { get; set; }
        public virtual DbSet<SupplyOrderDto> SupplyOrders { get; set; }
        public virtual DbSet<TransportStatusDto> TransportStatuses { get; set; }

        //Monitoring
        public virtual DbSet<AtmosphereConditionDto> AtmosphereConditions { get; set; }

        //Payment 
        public virtual DbSet<PaymentDto> Payments { get; set; }
        public virtual DbSet<PaymentMethodDto> PaymentMethods { get; set; }
        public virtual DbSet<PaymentStatusDto> PaymentStatuses { get; set; }

        //Sales
        public virtual DbSet<SalesOrderDto> SalesOrders { get; set; }
        public virtual DbSet<SalesOrderLineDto> SalesOrderLines { get; set; }
        public virtual DbSet<SalesOrderShippingDto> SalesOrderShippings { get; set; }
        public virtual DbSet<SalesOrderStatusDto> SalesOrderStatuses { get; set; }

        //Utilities
        public virtual DbSet<AddressDto> Addresses { get; set; }
        public virtual DbSet<PlaceDto> Places { get; set; }
        public virtual DbSet<PositionDto> Positions { get; set; }
        public virtual DbSet<SizeDto> Sizes { get; set; }

        //Warehouse
        public virtual DbSet<ProductDto> Products { get; set; }
        public virtual DbSet<CompanyDto> Companies { get; set; }
        public virtual DbSet<PalletDto> Pallets { get; set; }
        public virtual DbSet<PlantDto> Plants { get; set; }
        public virtual DbSet<RackDto> Racks { get; set; }
        public virtual DbSet<InventoryItemDto> InventoryItems { get; set; }

        internal ApplicationDbContext CreateDbContext(object i)
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
