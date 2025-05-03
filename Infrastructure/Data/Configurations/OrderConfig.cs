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
    internal class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.Property(o => o.OrderId).HasColumnName("order_id");
            entity.Property(o => o.OrderId).HasColumnName("order_id");
            entity.Property(o => o.CustomerId).HasColumnName("customer_id");
            entity.Property(o => o.TotalPayment).HasColumnName("total_payment");
            entity.Property(o => o.RemainPayment).HasColumnName("remain_payment");
            entity.Property(o => o.DiscountType).HasColumnName("discount_type");
            entity.Property(o => o.DiscountValue).HasColumnName("discount_value");
            entity.Property(o => o.Status).HasColumnName("status").HasConversion<string>();
        }
    }
}
