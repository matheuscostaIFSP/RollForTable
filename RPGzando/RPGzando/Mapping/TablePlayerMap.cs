using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RPGzando.Models;

namespace RPGzando.Mapping
{
    public class TablePlayerMap : IEntityTypeConfiguration<TablePlayer>
    {
        public void Configure(EntityTypeBuilder<TablePlayer> builder)
        {
            builder.HasKey(p => p.TablePlayerId);

            builder.Property(p => p.DateIngress).IsRequired();

            builder.HasOne(p => p.User).WithMany(p => p.TablePlayers).HasForeignKey(p => p.UserId);
            builder.HasOne(p => p.TableGame).WithMany(p => p.TablePlayers).HasForeignKey(p => p.TableGameId);

            builder.ToTable("TablePlayers");

        }
    }
}
