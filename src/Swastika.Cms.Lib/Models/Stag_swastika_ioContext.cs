using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Swastika.Cms.Lib.Models
{
    public partial class Stag_swastika_ioContext : DbContext
    {
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<BaseConfiguration> BaseConfiguration { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<RefreshTokens> RefreshTokens { get; set; }
        public virtual DbSet<SiocArticle> SiocArticle { get; set; }
        public virtual DbSet<SiocArticleModule> SiocArticleModule { get; set; }
        public virtual DbSet<SiocBanner> SiocBanner { get; set; }
        public virtual DbSet<SiocCategory> SiocCategory { get; set; }
        public virtual DbSet<SiocCategoryArticle> SiocCategoryArticle { get; set; }
        public virtual DbSet<SiocCategoryCategory> SiocCategoryCategory { get; set; }
        public virtual DbSet<SiocCategoryModule> SiocCategoryModule { get; set; }
        public virtual DbSet<SiocCategoryPosition> SiocCategoryPosition { get; set; }
        public virtual DbSet<SiocComment> SiocComment { get; set; }
        public virtual DbSet<SiocConfiguration> SiocConfiguration { get; set; }
        public virtual DbSet<SiocCopy> SiocCopy { get; set; }
        public virtual DbSet<SiocCulture> SiocCulture { get; set; }
        public virtual DbSet<SiocModule> SiocModule { get; set; }
        public virtual DbSet<SiocModuleArticle> SiocModuleArticle { get; set; }
        public virtual DbSet<SiocModuleAttributeSet> SiocModuleAttributeSet { get; set; }
        public virtual DbSet<SiocModuleAttributeValue> SiocModuleAttributeValue { get; set; }
        public virtual DbSet<SiocModuleData> SiocModuleData { get; set; }
        public virtual DbSet<SiocParameter> SiocParameter { get; set; }
        public virtual DbSet<SiocPosition> SiocPosition { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Server=115.77.190.113,4444;Database=Stag_swastika_io;UID=sa;Pwd=sqlP@ssw0rd;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CountryId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Dob).HasColumnName("DOB");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.JoinDate).HasDefaultValueSql("('0001-01-01T00:00:00.000')");

                entity.Property(e => e.LastModified).HasDefaultValueSql("('0001-01-01T00:00:00.000')");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<BaseConfiguration>(entity =>
            {
                entity.HasKey(e => new { e.Keyword, e.Specificulture });

                entity.ToTable("base_configuration");

                entity.Property(e => e.Keyword).HasMaxLength(250);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.HasOne(d => d.SpecificultureNavigation)
                    .WithMany(p => p.BaseConfiguration)
                    .HasPrincipalKey(p => p.Specificulture)
                    .HasForeignKey(d => d.Specificulture)
                    .HasConstraintName("FK_Base_Configuration_TTS_Culture");
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.AllowedOrigin).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Secret).IsRequired();
            });

            modelBuilder.Entity<RefreshTokens>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ExpiresUtc).HasColumnType("datetime");

                entity.Property(e => e.IssuedUtc).HasColumnType("datetime");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SiocArticle>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Specificulture });

                entity.ToTable("sioc_article");

                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.SeoDescription).HasMaxLength(4000);

                entity.Property(e => e.SeoKeywords).HasMaxLength(4000);

                entity.Property(e => e.SeoName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SeoTitle).HasMaxLength(4000);

                entity.Property(e => e.Source).HasMaxLength(250);

                entity.Property(e => e.Tags).HasMaxLength(500);

                entity.Property(e => e.Template).HasMaxLength(50);

                entity.Property(e => e.Thumbnail).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(4000);

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.SpecificultureNavigation)
                    .WithMany(p => p.SiocArticle)
                    .HasPrincipalKey(p => p.Specificulture)
                    .HasForeignKey(d => d.Specificulture)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TTS_Article_TTS_Culture");
            });

            modelBuilder.Entity<SiocArticleModule>(entity =>
            {
                entity.HasKey(e => new { e.ModuleId, e.ArticleId, e.Specificulture });

                entity.ToTable("sioc_article_module");

                entity.Property(e => e.ArticleId).HasMaxLength(50);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.HasOne(d => d.SiocArticle)
                    .WithMany(p => p.SiocArticleModule)
                    .HasForeignKey(d => new { d.ArticleId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TTS_Article_Module_TTS_Article");

                entity.HasOne(d => d.SiocModule)
                    .WithMany(p => p.SiocArticleModule)
                    .HasForeignKey(d => new { d.ModuleId, d.Specificulture })
                    .HasConstraintName("FK_TTS_Article_Module_TTS_Module1");
            });

            modelBuilder.Entity<SiocBanner>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Specificulture });

                entity.ToTable("sioc_banner");

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Specificulture)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'en')");

                entity.Property(e => e.Alias).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ModifiedBy).HasMaxLength(450);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasDefaultValueSql("(N'#')");

                entity.HasOne(d => d.SpecificultureNavigation)
                    .WithMany(p => p.SiocBanner)
                    .HasPrincipalKey(p => p.Specificulture)
                    .HasForeignKey(d => d.Specificulture)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TTS_Banner_TTS_Culture");
            });

            modelBuilder.Entity<SiocCategory>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Specificulture });

                entity.ToTable("sioc_category");

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Icon).HasMaxLength(50);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Priority).HasDefaultValueSql("((0))");

                entity.Property(e => e.SeoDescription).HasMaxLength(4000);

                entity.Property(e => e.SeoKeywords).HasMaxLength(4000);

                entity.Property(e => e.SeoName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SeoTitle).HasMaxLength(4000);

                entity.Property(e => e.StaticUrl).HasMaxLength(250);

                entity.Property(e => e.Tags).HasMaxLength(500);

                entity.Property(e => e.Template).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(4000);

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.SpecificultureNavigation)
                    .WithMany(p => p.SiocCategory)
                    .HasPrincipalKey(p => p.Specificulture)
                    .HasForeignKey(d => d.Specificulture)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TTS_Category_TTS_Culture");
            });

            modelBuilder.Entity<SiocCategoryArticle>(entity =>
            {
                entity.HasKey(e => new { e.ArticleId, e.CategoryId, e.Specificulture });

                entity.ToTable("sioc_category_article");

                entity.Property(e => e.ArticleId).HasMaxLength(50);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.HasOne(d => d.SiocArticle)
                    .WithMany(p => p.SiocCategoryArticle)
                    .HasForeignKey(d => new { d.ArticleId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TTS_Category_Article_TTS_Article");

                entity.HasOne(d => d.SiocCategory)
                    .WithMany(p => p.SiocCategoryArticle)
                    .HasForeignKey(d => new { d.CategoryId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TTS_Category_Article_TTS_Category");
            });

            modelBuilder.Entity<SiocCategoryCategory>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ParentId, e.Specificulture });

                entity.ToTable("sioc_category_category");

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.HasOne(d => d.SiocCategory)
                    .WithMany(p => p.SiocCategoryCategorySiocCategory)
                    .HasForeignKey(d => new { d.Id, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TTS_Category_Category_TTS_Category");

                entity.HasOne(d => d.SiocCategoryNavigation)
                    .WithMany(p => p.SiocCategoryCategorySiocCategoryNavigation)
                    .HasForeignKey(d => new { d.ParentId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TTS_Category_Category_TTS_Category1");
            });

            modelBuilder.Entity<SiocCategoryModule>(entity =>
            {
                entity.HasKey(e => new { e.ModuleId, e.CategoryId, e.Specificulture });

                entity.ToTable("sioc_category_module");

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.HasOne(d => d.SiocCategory)
                    .WithMany(p => p.SiocCategoryModule)
                    .HasForeignKey(d => new { d.CategoryId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TTS_Category_Module_TTS_Category");

                entity.HasOne(d => d.SiocModule)
                    .WithMany(p => p.SiocCategoryModule)
                    .HasForeignKey(d => new { d.ModuleId, d.Specificulture })
                    .HasConstraintName("FK_TTS_Menu_Module_TTS_Module1");
            });

            modelBuilder.Entity<SiocCategoryPosition>(entity =>
            {
                entity.HasKey(e => new { e.PositionId, e.CategoryId, e.Specificulture });

                entity.ToTable("sioc_category_position");

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.SiocCategoryPosition)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_TTS_Category_Position_TTS_Position");

                entity.HasOne(d => d.SiocCategory)
                    .WithMany(p => p.SiocCategoryPosition)
                    .HasForeignKey(d => new { d.CategoryId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TTS_Category_Position_TTS_Category");
            });

            modelBuilder.Entity<SiocComment>(entity =>
            {
                entity.ToTable("sioc_comment");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.FullName).HasMaxLength(250);

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<SiocConfiguration>(entity =>
            {
                entity.HasKey(e => new { e.Keyword, e.Specificulture });

                entity.ToTable("sioc_configuration");

                entity.Property(e => e.Keyword).HasMaxLength(250);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Category).HasMaxLength(250);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.HasOne(d => d.SpecificultureNavigation)
                    .WithMany(p => p.SiocConfiguration)
                    .HasPrincipalKey(p => p.Specificulture)
                    .HasForeignKey(d => d.Specificulture)
                    .HasConstraintName("FK_Sioc_Configuration_Sioc_Culture");
            });

            modelBuilder.Entity<SiocCopy>(entity =>
            {
                entity.HasKey(e => new { e.Culture, e.Keyword });

                entity.ToTable("sioc_copy");

                entity.Property(e => e.Culture).HasMaxLength(10);

                entity.Property(e => e.Keyword).HasMaxLength(250);

                entity.Property(e => e.Note).HasMaxLength(250);
            });

            modelBuilder.Entity<SiocCulture>(entity =>
            {
                entity.ToTable("sioc_culture");

                entity.HasIndex(e => e.Specificulture)
                    .HasName("IX_TTS_Culture")
                    .IsUnique();

                entity.Property(e => e.Alias).HasMaxLength(150);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.FullName).HasMaxLength(150);

                entity.Property(e => e.Icon).HasMaxLength(50);

                entity.Property(e => e.Lcid)
                    .HasColumnName("LCID")
                    .HasMaxLength(50);

                entity.Property(e => e.Specificulture)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<SiocModule>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Specificulture });

                entity.ToTable("sioc_module");

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Fields).HasMaxLength(4000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Template).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.Property(e => e.Type).HasDefaultValueSql("('0')");

                entity.HasOne(d => d.SpecificultureNavigation)
                    .WithMany(p => p.SiocModule)
                    .HasPrincipalKey(p => p.Specificulture)
                    .HasForeignKey(d => d.Specificulture)
                    .HasConstraintName("FK_TTS_Module_TTS_Culture");
            });

            modelBuilder.Entity<SiocModuleArticle>(entity =>
            {
                entity.HasKey(e => new { e.ArticleId, e.ModuleId, e.Specificulture });

                entity.ToTable("sioc_module_article");

                entity.Property(e => e.ArticleId).HasMaxLength(50);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.HasOne(d => d.SiocArticle)
                    .WithMany(p => p.SiocModuleArticle)
                    .HasForeignKey(d => new { d.ArticleId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TTS_Module_Article_TTS_Article");

                entity.HasOne(d => d.SiocModule)
                    .WithMany(p => p.SiocModuleArticle)
                    .HasForeignKey(d => new { d.ModuleId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TTS_Module_Article_TTS_Module");
            });

            modelBuilder.Entity<SiocModuleAttributeSet>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ModuleId, e.Specificulture });

                entity.ToTable("sioc_module_attribute_set");

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.ArticleId).HasMaxLength(50);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Fields)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.Priority).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.SiocModule)
                    .WithMany(p => p.SiocModuleAttributeSet)
                    .HasForeignKey(d => new { d.ModuleId, d.Specificulture })
                    .HasConstraintName("FK_TTS_Module_Attribute_set_TTS_Module");

                entity.HasOne(d => d.SiocArticleModule)
                    .WithMany(p => p.SiocModuleAttributeSet)
                    .HasForeignKey(d => new { d.ModuleId, d.ArticleId, d.Specificulture })
                    .HasConstraintName("FK_TTS_Module_Attribute_set_TTS_Article_Module");

                entity.HasOne(d => d.SiocCategoryModule)
                    .WithMany(p => p.SiocModuleAttributeSet)
                    .HasForeignKey(d => new { d.ModuleId, d.CategoryId, d.Specificulture })
                    .HasConstraintName("FK_TTS_Module_Attribute_set_TTS_Category_Module");
            });

            modelBuilder.Entity<SiocModuleAttributeValue>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.AttributeSetId, e.Specificulture });

                entity.ToTable("sioc_module_attribute_value");

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.DefaultValue)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.Property(e => e.Width).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.SiocModuleAttributeSet)
                    .WithMany(p => p.SiocModuleAttributeValue)
                    .HasForeignKey(d => new { d.AttributeSetId, d.ModuleId, d.Specificulture })
                    .HasConstraintName("FK_sioc_module_attribute_value_sioc_module_attribute_set");
            });

            modelBuilder.Entity<SiocModuleData>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ModuleId, e.Specificulture });

                entity.ToTable("sioc_module_data");

                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.ArticleId).HasMaxLength(50);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Fields)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.Priority).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.SiocModule)
                    .WithMany(p => p.SiocModuleData)
                    .HasForeignKey(d => new { d.ModuleId, d.Specificulture })
                    .HasConstraintName("FK_TTS_Module_Data_TTS_Module");

                entity.HasOne(d => d.SiocArticleModule)
                    .WithMany(p => p.SiocModuleData)
                    .HasForeignKey(d => new { d.ModuleId, d.ArticleId, d.Specificulture })
                    .HasConstraintName("FK_TTS_Module_Data_TTS_Article_Module");

                entity.HasOne(d => d.SiocCategoryModule)
                    .WithMany(p => p.SiocModuleData)
                    .HasForeignKey(d => new { d.ModuleId, d.CategoryId, d.Specificulture })
                    .HasConstraintName("FK_TTS_Module_Data_TTS_Category_Module");
            });

            modelBuilder.Entity<SiocParameter>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("sioc_parameter");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .ValueGeneratedNever();

                entity.Property(e => e.Value).IsRequired();
            });

            modelBuilder.Entity<SiocPosition>(entity =>
            {
                entity.ToTable("sioc_position");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);
            });
        }
    }
}
