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
    public class AuditLogConfig : IEntityTypeConfiguration<AuditLog>
    {
        public void Configure(EntityTypeBuilder<AuditLog> entity)
        {
            entity.ToTable("tbl_Audit_Log");
            entity.HasKey(e => e.LogId);
            entity.Property(al => al.TableName).HasColumnName("table_name");
            entity.Property(al => al.RecordId).HasColumnName("record_id");
            entity.Property(al => al.Action).HasColumnName("action");
            entity.Property(al => al.ActionBy).HasColumnName("action_by");
            entity.Property(al => al.ActionAt).HasColumnName("action_at");
            entity.Property(al => al.OldData).HasColumnName("old_data");
            entity.Property(al => al.NewData).HasColumnName("new_data");
        }
    }
}
