using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using Swastika.Common.Utility;

namespace Swastika.Messenger.Lib.Models
{   

    public partial class ChatContext : DbContext
    {
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<SiocChathubRoom> SiocChathubRoom { get; set; }
        public virtual DbSet<SiocChathubUser> SiocChathubUser { get; set; }
        public virtual DbSet<SiocChatTeam> SiocChatTeam { get; set; }
        public virtual DbSet<SiocChatTeamMember> SiocChatTeamMember { get; set; }
        public virtual DbSet<SiocChatTeamMessage> SiocChatTeamMessage { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Const.CONST_FILE_APPSETTING)
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString(Const.CONST_CHAT_CONNECTION));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Avatar).HasMaxLength(250);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.JoinDate).HasColumnType("datetime");

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey });

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<SiocChathubRoom>(entity =>
            {
                entity.HasKey(e => new { e.RoomName, e.UserId });

                entity.ToTable("sioc_chathub_room");

                entity.Property(e => e.RoomName).HasMaxLength(50);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.JoinedDate).HasColumnType("datetime");

                entity.Property(e => e.RoomTitle).HasMaxLength(250);

                entity.Property(e => e.TeamId).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SiocChathubRoom)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Ogilvy_Chat_Room_Ogilvy_ChatHub_User");
            });

            modelBuilder.Entity<SiocChathubUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("sioc_chathub_user");

                entity.Property(e => e.UserId)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.ConnectionId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.JoinedDate).HasColumnType("datetime");

                entity.Property(e => e.NickName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.SiocChathubUser)
                    .HasForeignKey<SiocChathubUser>(d => d.UserId)
                    .HasConstraintName("FK_Ogilvy_ChatHub_User_AspNetUsers");
            });

            modelBuilder.Entity<SiocChatTeam>(entity =>
            {
                entity.ToTable("sioc_chat_team");

                entity.Property(e => e.Avatar).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.HostId).HasMaxLength(128);

                entity.Property(e => e.IsOpen).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<SiocChatTeamMember>(entity =>
            {
                entity.HasKey(e => new { e.TeamId, e.MemberId });

                entity.ToTable("sioc_chat_team_member");

                entity.Property(e => e.MemberId).HasMaxLength(128);

                entity.Property(e => e.BannedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.JoinedDate).HasColumnType("datetime");

                entity.Property(e => e.SeenDate).HasColumnType("datetime");

                entity.Property(e => e.SeenInviteDate).HasColumnType("datetime");

                entity.Property(e => e.SeenMessageDate).HasColumnType("datetime");

                entity.Property(e => e.SeenRequestDate).HasColumnType("datetime");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.SiocChatTeamMember)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_Ogilvy_Team_Member_AspNetUsers");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.SiocChatTeamMember)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_Ogilvy_Team_Member_Ogilvy_Team");
            });

            modelBuilder.Entity<SiocChatTeamMessage>(entity =>
            {
                entity.ToTable("sioc_chat_team_message");

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.MessageType).HasDefaultValueSql("((0))");

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NotificationType).HasDefaultValueSql("((0))");

                entity.Property(e => e.UserAvatar).HasMaxLength(250);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.SiocChatTeamMessage)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_Ogilvy_Team_Message_Ogilvy_Team");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SiocChatTeamMessage)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Ogilvy_Team_Message_AspNetUsers");
            });
        }
    }
}
