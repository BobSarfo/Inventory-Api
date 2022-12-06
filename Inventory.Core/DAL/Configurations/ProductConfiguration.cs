using Inventory.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Core.Domain.ValueObjects;

namespace Inventory.Core.DAL.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.ProductName).IsUnique();

            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(250)
            .HasConversion(x => x.Value, x => new ProductName(x));
        }
    }
}
