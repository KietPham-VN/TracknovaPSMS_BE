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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.ToTable("tbl_Categories");
            entity.Property(c => c.CategoryId).HasColumnName("category_id");
            entity.Property(c => c.CategoryName).HasColumnName("category_name").IsRequired();
            entity.Property(c => c.PrioritizeScore).HasColumnName("prioritize_score");
            entity.Property(c => c.Status).HasColumnName("status").HasConversion<string>();
        }
    }
}
