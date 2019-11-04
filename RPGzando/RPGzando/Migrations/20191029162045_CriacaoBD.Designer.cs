﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RPGzando.Models;

namespace RPGzando.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20191029162045_CriacaoBD")]
    partial class CriacaoBD
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("RPGzando.Models.Card", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameCharacter")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PdfLink")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("UserId");

                    b.HasKey("CardId");

                    b.HasIndex("UserId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("RPGzando.Models.HoraryTable", b =>
                {
                    b.Property<int>("HoraryTableId");

                    b.Property<string>("DateAvailableTable")
                        .IsRequired();

                    b.Property<TimeSpan>("HoraryTableFinal");

                    b.Property<TimeSpan>("HoraryTableInitial");

                    b.Property<int>("TableGameId");

                    b.HasKey("HoraryTableId");

                    b.ToTable("HoraryTables");
                });

            modelBuilder.Entity("RPGzando.Models.HoraryUser", b =>
                {
                    b.Property<int>("HoraryUserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DateAvailable")
                        .IsRequired();

                    b.Property<TimeSpan>("HoraryUserFinal");

                    b.Property<TimeSpan>("HoraryUserInitial");

                    b.Property<string>("UserId");

                    b.HasKey("HoraryUserId");

                    b.HasIndex("UserId");

                    b.ToTable("HoraryUsers");
                });

            modelBuilder.Entity("RPGzando.Models.LevelAccesses", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("LevelAccesses");
                });

            modelBuilder.Entity("RPGzando.Models.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("TitleNotification")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("NotificationId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("RPGzando.Models.RegisteredPlayer", b =>
                {
                    b.Property<int>("RegisteredPlayerId");

                    b.Property<bool>("Accept");

                    b.Property<DateTime?>("DateIngress")
                        .IsRequired();

                    b.Property<int>("TableGameId");

                    b.Property<string>("UserId");

                    b.HasKey("RegisteredPlayerId");

                    b.HasIndex("UserId");

                    b.ToTable("RegisteredPlayers");
                });

            modelBuilder.Entity("RPGzando.Models.RoleUser", b =>
                {
                    b.Property<int>("RoleUserId");

                    b.Property<string>("DescriptionRole")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("NameRole")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("TableGameId");

                    b.Property<string>("UserId");

                    b.HasKey("RoleUserId");

                    b.HasIndex("UserId");

                    b.ToTable("RoleUsers");
                });

            modelBuilder.Entity("RPGzando.Models.Setting", b =>
                {
                    b.Property<int>("SettingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ReceiveEmail");

                    b.Property<bool>("ReceiveTelegram");

                    b.Property<bool>("Reminder");

                    b.Property<string>("UserId");

                    b.Property<bool>("Warning");

                    b.HasKey("SettingId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("RPGzando.Models.TableGame", b =>
                {
                    b.Property<int>("TableGameId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<DateTime?>("DateCreated")
                        .IsRequired();

                    b.Property<DateTime?>("DateInitial")
                        .IsRequired();

                    b.Property<string>("DescriptionGame")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Latitude");

                    b.Property<string>("LinkDiscord")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Longitude");

                    b.Property<string>("Photo")
                        .IsRequired();

                    b.Property<bool>("Presential");

                    b.Property<string>("QuantityPeople")
                        .IsRequired();

                    b.Property<string>("System")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("TableDuration");

                    b.Property<string>("Theme")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("TableGameId");

                    b.ToTable("TableGames");
                });

            modelBuilder.Entity("RPGzando.Models.TablePlayer", b =>
                {
                    b.Property<int>("TablePlayerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateIngress")
                        .IsRequired();

                    b.Property<int>("TableGameId");

                    b.Property<string>("UserId");

                    b.HasKey("TablePlayerId");

                    b.HasIndex("TableGameId");

                    b.HasIndex("UserId");

                    b.ToTable("TablePlayers");
                });

            modelBuilder.Entity("RPGzando.Models.TablePlayerNotification", b =>
                {
                    b.Property<int>("TpNotificationId");

                    b.Property<int>("NotificationId");

                    b.Property<int>("TableGameId");

                    b.HasKey("TpNotificationId");

                    b.HasIndex("NotificationId");

                    b.ToTable("TablePlayerNotifications");
                });

            modelBuilder.Entity("RPGzando.Models.TableSystemCard", b =>
                {
                    b.Property<int>("TableSystemCardId");

                    b.Property<int>("CardId");

                    b.Property<string>("SystemCard");

                    b.Property<int>("TableGameId");

                    b.HasKey("TableSystemCardId");

                    b.HasIndex("CardId");

                    b.ToTable("TableSystemCards");
                });

            modelBuilder.Entity("RPGzando.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime?>("DateRegister")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Latitude");

                    b.Property<string>("Longitude");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<bool>("PresentialUser");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("RPGzando.Models.LevelAccesses")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RPGzando.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RPGzando.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("RPGzando.Models.LevelAccesses")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RPGzando.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RPGzando.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RPGzando.Models.Card", b =>
                {
                    b.HasOne("RPGzando.Models.User", "User")
                        .WithMany("Cards")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("RPGzando.Models.HoraryTable", b =>
                {
                    b.HasOne("RPGzando.Models.TableGame", "TableGame")
                        .WithMany("HoraryTables")
                        .HasForeignKey("HoraryTableId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RPGzando.Models.HoraryUser", b =>
                {
                    b.HasOne("RPGzando.Models.User", "User")
                        .WithMany("HoraryUsers")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("RPGzando.Models.RegisteredPlayer", b =>
                {
                    b.HasOne("RPGzando.Models.TableGame", "TableGame")
                        .WithMany("RegisteredPlayer")
                        .HasForeignKey("RegisteredPlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RPGzando.Models.User", "User")
                        .WithMany("RegisteredPlayers")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("RPGzando.Models.RoleUser", b =>
                {
                    b.HasOne("RPGzando.Models.TableGame", "TableGame")
                        .WithMany("RoleUsers")
                        .HasForeignKey("RoleUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RPGzando.Models.User", "User")
                        .WithMany("RoleUsers")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("RPGzando.Models.Setting", b =>
                {
                    b.HasOne("RPGzando.Models.User", "User")
                        .WithOne("Setting")
                        .HasForeignKey("RPGzando.Models.Setting", "UserId");
                });

            modelBuilder.Entity("RPGzando.Models.TablePlayer", b =>
                {
                    b.HasOne("RPGzando.Models.TableGame", "TableGame")
                        .WithMany("TablePlayers")
                        .HasForeignKey("TableGameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RPGzando.Models.User", "User")
                        .WithMany("TablePlayers")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("RPGzando.Models.TablePlayerNotification", b =>
                {
                    b.HasOne("RPGzando.Models.Notification", "Notification")
                        .WithMany("TablePlayerNotifications")
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RPGzando.Models.TableGame", "TableGame")
                        .WithMany("TablePlayerNotifications")
                        .HasForeignKey("TpNotificationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RPGzando.Models.TableSystemCard", b =>
                {
                    b.HasOne("RPGzando.Models.Card", "Card")
                        .WithMany("TableSystemCards")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RPGzando.Models.TableGame", "TableGame")
                        .WithMany("TableSystemCards")
                        .HasForeignKey("TableSystemCardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
