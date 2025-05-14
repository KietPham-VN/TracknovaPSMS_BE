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
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("tbl_Users");
            entity.HasKey(u => u.UserId);
            entity.Property(u => u.Username).HasColumnName("username").HasMaxLength(20);
            entity.Property(u => u.FullName).HasColumnName("full_name").HasMaxLength(70);
            entity.Property(u => u.Password).HasColumnName("password").IsRequired();
            entity.Property(u => u.PhoneNumber).HasColumnName("phone_number").HasMaxLength(20);
            entity.Property(u => u.Email).HasColumnName("email").HasMaxLength(255);
            entity.Property(u => u.Address).HasColumnName("address");
            entity.Property(u => u.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(u => u.Role).HasColumnName("role").HasConversion<string>();
            entity.Property(u => u.PrioritizeScore).HasColumnName("prioritize_score");
            entity.Property(u => u.Status).HasColumnName("status").HasConversion<string>();
        }
    }

}
