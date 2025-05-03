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
    internal class ImportItemConfig : IEntityTypeConfiguration<ImportItem>
    {
        public void Configure(EntityTypeBuilder<ImportItem> entity)
        {
            entity.ToTable("tbl_Import_Item");
            entity.Property(ii => ii.ImportItemId).HasColumnName("import_item_id");
            entity.Property(ii => ii.ImportId).HasColumnName("import_id");
            entity.Property(ii => ii.ProductId).HasColumnName("product_id");
            entity.Property(ii => ii.ImportQuantity).HasColumnName("import_quantity");
            entity.Property(ii => ii.ImportPrice).HasColumnName("import_price");
            entity.Property(ii => ii.ExpiryDate).HasColumnName("expiry_date");
        }
    }
}
