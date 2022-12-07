using Inventory.Core.Domain.Entities;
using Inventory.Core.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.DAL.Configurations
{
    internal class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(250);


            builder.Property(x => x.CustomerName).IsRequired().HasMaxLength(250)            
            .HasConversion(x => x.Value, x => new CustomerName(x));


            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(250)
            .HasConversion(x => x.Value, x => new ProductName(x));
        }
    }
}
