using Inventory.Core.DAL;
using Inventory.Core.DAL.Repositories;
using Inventory.Core.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Inflow.Modules.Customers.Api")]
[assembly: InternalsVisibleTo("Inflow.Modules.Customers.Tests.Integration")]
[assembly: InternalsVisibleTo("Inflow.Modules.Customers.Tests.Unit")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace Inventory.Core
{
    internal static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();

            services.AddDbContext<InventoryDbContext>(option=>
            {
                option.UseNpgsql();
            });
            return services;
        }
    }
}