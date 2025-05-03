using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Configurations
{
    public class SupplierConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> entity)
        {
            entity.ToTable("tbl_Suppliers");
            entity.HasKey(s => s.SupplierId);
            entity.Property(s => s.SupplierName).HasColumnName("supplier_name").IsRequired();
            entity.Property(s => s.PrioritizeScore).HasColumnName("prioritize_score");
            entity.Property(s => s.Status).HasColumnName("status").HasConversion<string>();
        }
    }
}

