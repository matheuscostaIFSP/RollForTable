using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RPGzando.Models;

namespace RPGzando.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Name).IsRequired().HasMaxLength(50);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(30);
            builder.Property(U => U.Nickname).IsRequired().HasMaxLength(30);
            builder.Property(u => u.DateRegister);
            builder.Property(u => u.PresentialUser);
            builder.Property(u => u.Latitude);
            builder.Property(u => u.Longitude);

            builder.Ignore(i => i.EmailConfirmed);
            builder.Ignore(i => i.AccessFailedCount);
            builder.Ignore(i => i.LockoutEnabled);
            builder.Ignore(i => i.LockoutEnd);
            builder.Ignore(i => i.PhoneNumber);
            builder.Ignore(i => i.PhoneNumberConfirmed);
            builder.Ignore(i => i.TwoFactorEnabled);

            builder.HasMany(u => u.Cards).WithOne(u => u.User);
            builder.HasMany(u => u.TablePlayers).WithOne(u => u.User);
            builder.HasMany(u => u.HoraryUsers).WithOne(u => u.User);
            builder.HasMany(u => u.RegisteredPlayers).WithOne(u => u.User);
            builder.HasMany(u => u.RoleUsers).WithOne(u => u.User);
            builder.HasOne(u => u.Setting).WithOne(u => u.User);

            builder.ToTable("Users");
        }
    }
}
