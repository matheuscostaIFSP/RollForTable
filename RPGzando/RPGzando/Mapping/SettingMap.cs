using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RPGzando.Models;

namespace RPGzando.Mapping
{
    public class SettingMap : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.HasKey(s => s.SettingId);

            builder.Property(s => s.ReceiveEmail);
            builder.Property(s => s.ReceiveTelegram);
            builder.Property(s => s.Reminder);
            builder.Property(s => s.Warning);

            builder.HasOne(s => s.User).WithOne(s => s.Setting);

            builder.ToTable("Settings");
        }

    }
}
