using Inventory.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.DAL
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Sale> Sales { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>().HasData
                (
                    new Sale
                    {
                        Id = 1,
                        CustomerName = "Dave",
                        ProductName = "Laptop",
                        ProductPrice = 900
                    },
                    new Sale
                    {
                        Id = 2,
                        CustomerName = "George",
                        ProductName = "keyboard",
                        ProductPrice = 35

                    },
                    new Sale
                    {
                        Id = 3,
                        CustomerName = "Fiona",
                        ProductName = "paper",
                        ProductPrice = 5
                    },
                    new Sale
                    {
                        Id = 4,
                        CustomerName = "Rory",
                        ProductName = "paper",
                        ProductPrice = 3
                    },
                    new Sale
                    {
                        Id = 5,
                        CustomerName = "Olivia",
                        ProductName = "laptop",
                        ProductPrice = 600
                    }
                );

            modelBuilder.Entity<Product>().HasData
                (
                    new Product
                    {
                        Id = 1,
                        ProductName = "laptop",
                        Price = 600
                    },
                     new Product
                     {
                         Id = 1,
                         ProductName = "paper",
                         Price = 3
                     },
                      new Product
                      {
                          Id = 1,
                          ProductName = "keyboard",
                          Price = 35
                      }
                );

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

    }
}
