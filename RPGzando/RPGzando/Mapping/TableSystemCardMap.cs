using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RPGzando.Models;

namespace RPGzando.Mapping
{
    public class TableSystemCardMap : IEntityTypeConfiguration<TableSystemCard>
    {
        public void Configure(EntityTypeBuilder<TableSystemCard> builder)
        {
            builder.HasKey(s => s.TableSystemCardId);

            builder.HasOne(s => s.Card).WithMany(r => r.TableSystemCards).HasForeignKey(r => r.CardId);
            builder.HasOne(s => s.TableGame).WithMany(r => r.TableSystemCards).HasForeignKey(r => r.TableGameId);

            builder.ToTable("TableSystemCards");
        }
    }
}
