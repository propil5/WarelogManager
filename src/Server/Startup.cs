using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using WarelogManager.Model.Repositories;
using WarelogManager.Model.Repositories.Warehouse;
using WarelogManager.Model.Repositories.Warehouse.Interface;
using WarelogManager.Model.DataTransfer.Common;
using WarelogManager.Model.Mapping;
using WarelogManager.Model.Services.Warehouse.Interface;
using WarelogManager.Model.Services.Warehouse;
using WarelogManager.Model.Repositories.UnitOfWork;
using AutoMapper;
using WarelogManager.Model.Repositories.Sales;
using WarelogManager.Model.Repositories.Sales.Interface;
using WarelogManager.Model.Services.Sales.Interface;
using WarelogManager.Model.Services.Sales;

namespace WarelogManager.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(
                        Configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging(true);
            });

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ModelToResourceProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);


            //Repositories
            services.AddScoped<ICompanyRepository, CompanyRepository>()
                    .AddScoped<IPalletRepository, PalletRepository>()
                    .AddScoped<IPlantRepository, PlantRepository>()
                    .AddScoped<IProductRepository, ProductRepository>()
                    .AddScoped<IInventoryItemRepository, InventoryItemRepository>()
                    .AddScoped<IInventoryItemImageRepository, InventoryItemImageRepository>()
                    .AddScoped<IBasketItemRepository, BasketItemRepository>()
                    .AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();


            //Services
            services.AddScoped<ICompanyService, CompanyService>()
                    .AddScoped<IProductService, ProductService>()
                    .AddScoped<IInventoryItemService, InventoryItemService>()
                    .AddScoped<IBasketItemService, BasketItemService>()
                    .AddScoped<IPurchaseOrderService, PurchaseOrderService>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddSwaggerGen();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
