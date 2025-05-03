using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data.Configurations
{
    public class ImportConfig : IEntityTypeConfiguration<Import>
    {
        public void Configure(EntityTypeBuilder<Import> entity)
        {
            entity.ToTable("tbl_Imports");
            entity.Property(i => i.ImportId).HasColumnName("import_id");
            entity.Property(i => i.SupplierId).HasColumnName("supplier_id");
            entity.Property(i => i.TotalPayment).HasColumnName("total_payment");
            entity.Property(i => i.Status).HasColumnName("status").HasConversion<string>();
        }
    }
}
