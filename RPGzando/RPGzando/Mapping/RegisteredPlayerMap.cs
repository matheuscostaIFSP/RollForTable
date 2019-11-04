using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RPGzando.Models;

namespace RPGzando.Mapping
{
    public class RegisteredPlayerMap : IEntityTypeConfiguration<RegisteredPlayer>
    {
        public void Configure(EntityTypeBuilder<RegisteredPlayer> builder)
        {
            builder.HasKey(p => p.RegisteredPlayerId);

            builder.Property(p => p.DateIngress).IsRequired();
            builder.Property(p => p.Accept);

            builder.HasOne(p => p.User).WithMany(p => p.RegisteredPlayers).HasForeignKey(p => p.UserId);
            builder.HasOne(p => p.TableGame).WithMany(p => p.RegisteredPlayer).HasForeignKey(p => p.TableGameId);

            builder.ToTable("RegisteredPlayers");

        }
    }
}
