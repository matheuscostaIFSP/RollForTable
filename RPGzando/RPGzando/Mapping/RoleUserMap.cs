using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RPGzando.Models;

namespace RPGzando.Mapping
{
    public class RoleUserMap : IEntityTypeConfiguration<RoleUser>
    {
        public void Configure(EntityTypeBuilder<RoleUser> builder)
        {
            builder.HasKey(r => r.RoleUserId);
            builder.Property(r => r.NameRole).IsRequired().HasMaxLength(50);
            builder.Property(r => r.DescriptionRole).IsRequired().HasMaxLength(250);

            builder.HasOne(r => r.TableGame).WithMany(r => r.RoleUsers).HasForeignKey(r => r.TableGameId);
            builder.HasOne(r => r.User).WithMany(r => r.RoleUsers).HasForeignKey(r => r.UserId);

            builder.ToTable("RoleUsers");
        }

    }
}
