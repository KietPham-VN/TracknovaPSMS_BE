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
    public class Product_SupplierConfig : IEntityTypeConfiguration<ProductSupplier>
    {
        public void Configure(EntityTypeBuilder<ProductSupplier> entity)
        {
            entity.ToTable("tbl_Product_Supplier");
            entity.HasKey(e => new { e.ProductId, e.SupplierId });
        }
    }
}
