using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> entity)
        {
            entity.ToTable("tbl_Inventory");
            entity.HasKey(i => i.InventoryId);
            entity.Property(i => i.ProductId).HasColumnName("product_id");
            entity.Property(i => i.CurrentQuantity).HasColumnName("current_quantity");
            entity.Property(i => i.ExpiryDate).HasColumnName("expiry_date");
        }
    }
}
