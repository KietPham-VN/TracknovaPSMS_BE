using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Configurations
{
    public class PricingConfig : IEntityTypeConfiguration<Pricing>
    {
        public void Configure(EntityTypeBuilder<Pricing> entity)
        {
            entity.ToTable("tbl_Pricing");
            entity.Property(p => p.PricingId).HasColumnName("pricing_id");
            entity.Property(p => p.ProductId).HasColumnName("product_id");
            entity.Property(p => p.PricingValue).HasColumnName("pricing_value");
            entity.Property(p => p.UnitType).HasColumnName("unit_type");
            entity.Property(p => p.ExchangeQuantity).HasColumnName("exchange_quantity");
        }
    }
}
