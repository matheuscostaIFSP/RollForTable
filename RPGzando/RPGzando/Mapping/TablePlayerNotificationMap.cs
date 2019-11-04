using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RPGzando.Models;

namespace RPGzando.Mapping
{
    public class TablePlayerNotificationMap : IEntityTypeConfiguration<TablePlayerNotification>
    {
        public void Configure(EntityTypeBuilder<TablePlayerNotification> builder)
        {
            builder.HasKey(m => m.TpNotificationId);

            builder.HasOne(m => m.TableGame).WithMany(m => m.TablePlayerNotifications).HasForeignKey(m => m.TableGameId);
            builder.HasOne(m => m.Notification).WithMany(m => m.TablePlayerNotifications).HasForeignKey(m => m.NotificationId);

            builder.ToTable("TablePlayerNotifications");
        }
    }
}
