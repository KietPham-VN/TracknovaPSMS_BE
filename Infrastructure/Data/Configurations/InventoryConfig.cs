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
    internal class InventoryConfig : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> entity)
        {
            entity.ToTable("tbl_Products");
            entity.HasKey(p => p.ProductId);
            entity.Property(p => p.ScanCode).HasColumnName("scan_code").IsRequired();
            entity.Property(p => p.ProductName).HasColumnName("product_name").IsRequired();
            entity.Property(p => p.Description).HasColumnName("description");
            entity.Property(p => p.PrioritizeScore).HasColumnName("prioritize_score");
            entity.Property(p => p.Status).HasColumnName("status").HasConversion<string>();
        }
    }
}
