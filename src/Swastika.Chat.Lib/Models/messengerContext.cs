using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Swastika.Messenger.Lib.Models
{
    public partial class MessengerContext : DbContext
    {
        public virtual DbSet<MessengerHubRoom> MessengerHubRoom { get; set; }
        public virtual DbSet<MessengerMessage> MessengerMessage { get; set; }
        public virtual DbSet<MessengerNavRoomUser> MessengerNavRoomUser { get; set; }
        public virtual DbSet<MessengerNavTeamUser> MessengerNavTeamUser { get; set; }
        public virtual DbSet<MessengerTeam> MessengerTeam { get; set; }
        public virtual DbSet<MessengerUser> MessengerUser { get; set; }

        public MessengerContext()
        {

        }

        public MessengerContext(DbContextOptions<MessengerContext> options): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile(Common.Utility.Const.CONST_FILE_APPSETTING)
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString(Common.Utility.Const.CONST_CHAT_CONNECTION));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MessengerHubRoom>(entity =>
            {
                entity.ToTable("messenger_hub_room");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Avatar).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.HostId).HasMaxLength(128);

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<MessengerMessage>(entity =>
            {
                entity.ToTable("messenger_message");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Content).HasColumnType("ntext");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.MessengerMessage)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_messenger_message_messenger_hub_room");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.MessengerMessage)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_messenger_message_messenger_team");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MessengerMessage)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_messenger_message_messenger_user");
            });

            modelBuilder.Entity<MessengerNavRoomUser>(entity =>
            {
                entity.HasKey(e => new { e.RoomId, e.UserId });

                entity.ToTable("messenger_nav_room_user");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.JoinedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.MessengerNavRoomUser)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_messenger_nav_room_user_messenger_hub_room");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MessengerNavRoomUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_messenger_nav_room_user_messenger_user");
            });

            modelBuilder.Entity<MessengerNavTeamUser>(entity =>
            {
                entity.HasKey(e => new { e.TeamId, e.UserId });

                entity.ToTable("messenger_nav_team_user");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.JoinedDate).HasColumnType("datetime");

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.MessengerNavTeamUser)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_messenger_nav_team_user_messenger_team");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MessengerNavTeamUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_messenger_nav_team_user_messenger_user");
            });

            modelBuilder.Entity<MessengerTeam>(entity =>
            {
                entity.ToTable("messenger_team");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Avatar).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.HostId).HasMaxLength(128);

                entity.Property(e => e.IsOpen).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<MessengerUser>(entity =>
            {
                entity.ToTable("messenger_user");

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Avatar).HasMaxLength(250);

                entity.Property(e => e.ConnectionId).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);
            });
        }
    }
}
