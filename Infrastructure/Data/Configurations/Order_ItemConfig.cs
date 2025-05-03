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
    public class Order_ItemConfig : IEntityTypeConfiguration<Order_Item>
    {
        public void Configure(EntityTypeBuilder<Order_Item> entity)
        {
            entity.ToTable("tbl_Order_Items");
            entity.Property(oi => oi.OrderItemId).HasColumnName("order_item_id");
            entity.Property(oi => oi.OrderId).HasColumnName("order_id");
            entity.Property(oi => oi.ProductId).HasColumnName("product_id");
            entity.Property(oi => oi.Quantity).HasColumnName("quantity");
            entity.Property(oi => oi.CustomPrice).HasColumnName("custom_price");
        }
    }
}
