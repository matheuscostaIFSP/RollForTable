using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RPGzando.Mapping;
using RPGzando.Models;

namespace RPGzando.Models
{
    public class Context : IdentityDbContext<User, LevelAccesses, string>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TableGame> TableGames { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<HoraryUser> HoraryUsers { get; set; }
        public DbSet<HoraryTable> HoraryTables { get; set; }
        public DbSet<LevelAccesses> LevelAccesses { get; set; }
        public DbSet<TablePlayer> TablePlayers { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<RegisteredPlayer> RegisteredPlayers { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<TablePlayerNotification> TablePlayerNotifications { get; set; }
        public DbSet<TableSystemCard> TableSystemCards { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new LevelAccessMap());
            builder.ApplyConfiguration(new HoraryUserMap());
            builder.ApplyConfiguration(new HoraryTableMap());
            builder.ApplyConfiguration(new RoleUserMap());
            builder.ApplyConfiguration(new CardMap());
            builder.ApplyConfiguration(new TablePlayerMap());
            builder.ApplyConfiguration(new NotificationMap());
            builder.ApplyConfiguration(new RegisteredPlayerMap());
            builder.ApplyConfiguration(new SettingMap());
            builder.ApplyConfiguration(new TablePlayerNotificationMap());
            builder.ApplyConfiguration(new TableSystemCardMap());
            builder.ApplyConfiguration(new TableGameMap());

        }

        public DbSet<RPGzando.Models.HoraryTable> HoraryTable { get; set; }
    }
}
