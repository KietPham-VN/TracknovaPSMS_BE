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
    public class TransactionConfig : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> entity)
        {
            entity.ToTable("tbl_Transactions");
            entity.Property(t => t.TransactionId).HasColumnName("transaction_id");
            entity.Property(t => t.OrderId).HasColumnName("order_id");
            entity.Property(t => t.Amount).HasColumnName("amount");
            entity.Property(t => t.Description).HasColumnName("description");
            entity.Property(t => t.TransactionType).HasColumnName("transaction_type").HasConversion<string>();
            entity.Property(t => t.Status).HasColumnName("status").HasConversion<string>();
        }
    }
}
