using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RPGzando.Models;

namespace RPGzando.Mapping
{
    public class HoraryUserMap : IEntityTypeConfiguration<HoraryUser>
    {
        public void Configure(EntityTypeBuilder<HoraryUser> builder)
        {
            builder.HasKey(hu => hu.HoraryUserId);
            builder.Property(hu => hu.DateAvailable).IsRequired();
            builder.Property(hu => hu.HoraryUserInitial).IsRequired();
            builder.Property(hu => hu.HoraryUserFinal).IsRequired();

            builder.HasOne(hu => hu.User).WithMany(hu => hu.HoraryUsers).HasForeignKey(hu => hu.UserId);

            builder.ToTable("HoraryUsers");
        }
    }
}
