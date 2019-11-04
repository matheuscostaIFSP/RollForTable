using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RPGzando.Models;

namespace RPGzando.Mapping
{
    public class TableGameMap : IEntityTypeConfiguration<TableGame>
    {
        public void Configure(EntityTypeBuilder<TableGame> builder)
        {
            builder.HasKey(g => g.TableGameId);
            builder.Property(g => g.Title).IsRequired().HasMaxLength(50);
            builder.Property(g => g.DateCreated);
            builder.Property(g => g.DateInitial).IsRequired();
            builder.Property(g => g.System).IsRequired().HasMaxLength(30);
            builder.Property(g => g.DescriptionGame).IsRequired().HasMaxLength(250);
            builder.Property(g => g.Theme).IsRequired().HasMaxLength(50);
            builder.Property(g => g.QuantityPeople).IsRequired();
            builder.Property(g => g.TableDuration).IsRequired();
            builder.Property(g => g.LinkDiscord).IsRequired().HasMaxLength(250);
            builder.Property(g => g.Photo).IsRequired();
            builder.Property(g => g.Presential);
            builder.Property(g => g.Address1);
            builder.Property(g => g.Address2);
            builder.Property(g => g.Latitude);
            builder.Property(g => g.Longitude);

            builder.HasMany(g => g.TableSystemCards).WithOne(g => g.TableGame).HasForeignKey(g => g.TableSystemCardId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(g => g.TablePlayers).WithOne(g => g.TableGame).HasForeignKey(g => g.TableGameId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(g => g.HoraryTables).WithOne(g => g.TableGame).HasForeignKey(g => g.HoraryTableId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(g => g.RoleUsers).WithOne(g => g.TableGame).HasForeignKey(g => g.RoleUserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(g => g.RegisteredPlayer).WithOne(g => g.TableGame).HasForeignKey(g => g.RegisteredPlayerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(g => g.TablePlayerNotifications).WithOne(g => g.TableGame).HasForeignKey(g => g.TpNotificationId).OnDelete(DeleteBehavior.Cascade);


            builder.ToTable("TableGames");
        }
    }
}
