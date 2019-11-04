using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RPGzando.Models;

namespace RPGzando.Mapping
{
    public class NotificationMap : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(n => n.NotificationId);
            builder.Property(n => n.TitleNotification).IsRequired().HasMaxLength(50);
            builder.Property(n => n.Message).IsRequired().HasMaxLength(250);

            builder.HasMany(n => n.TablePlayerNotifications).WithOne(n => n.Notification).HasForeignKey(n => n.TpNotificationId);

            builder.ToTable("Notifications");
        }
    }
}
