using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sio.Cms.Lib;
using Sio.Cms.Lib.Services;

namespace Sio.Cms.Messenger.Models.Data
{
    public partial class SioChatServiceContext : DbContext
    {
        public SioChatServiceContext()
        {
        }

        public SioChatServiceContext(DbContextOptions<sw_chatContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SioMessengerHubRoom> SioMessengerHubRoom { get; set; }
        public virtual DbSet<SioMessengerMessage> SioMessengerMessage { get; set; }
        public virtual DbSet<SioMessengerNavRoomUser> SioMessengerNavRoomUser { get; set; }
        public virtual DbSet<SioMessengerNavTeamUser> SioMessengerNavTeamUser { get; set; }
        public virtual DbSet<SioMessengerTeam> SioMessengerTeam { get; set; }
        public virtual DbSet<SioMessengerUser> SioMessengerUser { get; set; }
        public virtual DbSet<SioMessengerUserDevice> SioMessengerUserDevice { get; set; }

        private static string _cnn = "Server=(localdb)\\mssqllocaldb;Database=sio-messenger.db;Trusted_Connection=True;MultipleActiveResultSets=true";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //define the database to use
                //string cnn = "Data Source=sio-messenger.db";
                //optionsBuilder.UseSqlite(cnn);
                 ;
                // IConfiguration configuration = new ConfigurationBuilder()
                //.SetBasePath(System.IO.Directory.GetCurrentDirectory())
                //.AddJsonFile(Common.Utility.Const.CONST_FILE_APPSETTING)
                //.Build();

                // //optionsBuilder.UseSqlServer(cnn);
                // string cnn = configuration.GetConnectionString("SioMessengerConnection");
                // if (string.IsNullOrEmpty(cnn))
                // {
                //     cnn = _cnn;
                // }
                // //define the database to use
                // if (!string.IsNullOrEmpty(cnn))
                // {
                //         optionsBuilder.UseSqlServer(cnn);
                // }

                string cnn = SioService.GetConnectionString(SioConstants.CONST_CMS_CONNECTION);
                if (!string.IsNullOrEmpty(cnn))
                {
                    if (SioService.GetConfig<bool>("IsSqlite"))
                    {
                        optionsBuilder.UseSqlite(cnn);
                    }
                    else
                    {
                        optionsBuilder.UseSqlServer(cnn);
                    }
                }
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SioMessengerHubRoom>(entity =>
            {
                entity.ToTable("sio_messenger_hub_room");

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

            modelBuilder.Entity<SioMessengerMessage>(entity =>
            {
                entity.ToTable("sio_messenger_message");

                entity.HasIndex(e => e.RoomId)
                    .HasName("IX_messenger_message_RoomId");

                entity.HasIndex(e => e.TeamId)
                    .HasName("IX_messenger_message_TeamId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_messenger_message_UserId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Content).HasColumnType("ntext");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.SioMessengerMessage)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_messenger_message_messenger_hub_room");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.SioMessengerMessage)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_messenger_message_messenger_team");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SioMessengerMessage)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_messenger_message_messenger_user");
            });

            modelBuilder.Entity<SioMessengerNavRoomUser>(entity =>
            {
                entity.HasKey(e => new { e.RoomId, e.UserId });

                entity.ToTable("sio_messenger_nav_room_user");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_messenger_nav_room_user_UserId");

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.Property(e => e.JoinedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.SioMessengerNavRoomUser)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_messenger_nav_room_user_messenger_hub_room");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SioMessengerNavRoomUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_messenger_nav_room_user_messenger_user");
            });

            modelBuilder.Entity<SioMessengerNavTeamUser>(entity =>
            {
                entity.HasKey(e => new { e.TeamId, e.UserId });

                entity.ToTable("sio_messenger_nav_team_user");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_messenger_nav_team_user_UserId");

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.Property(e => e.JoinedDate).HasColumnType("datetime");

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.SioMessengerNavTeamUser)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_messenger_nav_team_user_messenger_team");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SioMessengerNavTeamUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_messenger_nav_team_user_messenger_user");
            });

            modelBuilder.Entity<SioMessengerTeam>(entity =>
            {
                entity.ToTable("sio_messenger_team");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Avatar).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.HostId).HasMaxLength(128);

                entity.Property(e => e.IsOpen).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<SioMessengerUser>(entity =>
            {
                entity.ToTable("sio_messenger_user");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Avatar).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FacebookId).HasMaxLength(50);

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<SioMessengerUserDevice>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.DeviceId });

                entity.ToTable("sio_messenger_user_device");

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.Property(e => e.DeviceId).HasMaxLength(50);

                entity.Property(e => e.ConnectionId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });
        }
    }
}
