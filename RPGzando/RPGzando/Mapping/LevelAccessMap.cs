using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RPGzando.Models;

namespace RPGzando.Mapping
{
    public class LevelAccessMap : IEntityTypeConfiguration<LevelAccesses>
    {
        public void Configure(EntityTypeBuilder<LevelAccesses> builder)
        {
            builder.Property(l => l.Description).IsRequired().HasMaxLength(100);

            builder.ToTable("LevelAccesses");
        }
    }
}
