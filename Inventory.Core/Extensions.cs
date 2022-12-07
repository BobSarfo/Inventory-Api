using Inventory.Core.DAL;
using Inventory.Core.DAL.Repositories;
using Inventory.Core.Domain.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Inventory.Api")]
[assembly: InternalsVisibleTo("Inflow.Modules.Customers.Tests.Integration")]
[assembly: InternalsVisibleTo("Inflow.Modules.Customers.Tests.Unit")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace Inventory.Core
{
    public static class Extensions
    {
        public static IServiceCollection AddDomainCore(this IServiceCollection services)
        {

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();


            return services;
        }

        public static IServiceCollection AddDb(this IServiceCollection services,string conn)
        {
            services.AddDbContext<InventoryDbContext>(option =>
                {
                    option.UseNpgsql(conn, b => b.MigrationsAssembly(typeof(InventoryDbContext).Assembly.ToString()));
                });

            return services;
        }

        public static IApplicationBuilder UseDbMigration(this IApplicationBuilder app)
        { 
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<InventoryDbContext>();
                context.Database.Migrate();
            }
            return app;
        }


    }
}