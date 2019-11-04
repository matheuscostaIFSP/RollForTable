using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RPGzando.Models;

namespace RPGzando.Mapping
{
    public class HoraryTableMap : IEntityTypeConfiguration<HoraryTable>
    {
        public void Configure(EntityTypeBuilder<HoraryTable> builder)
        {
            builder.HasKey(ht => ht.HoraryTableId);
            builder.Property(ht => ht.DateAvailableTable).IsRequired();
            builder.Property(ht => ht.HoraryTableInitial).IsRequired();
            builder.Property(ht => ht.HoraryTableFinal).IsRequired();

            builder.HasOne(ht => ht.TableGame).WithMany(hu => hu.HoraryTables).HasForeignKey(hu => hu.TableGameId);

            builder.ToTable("HoraryTables");
        }
    }
}
