// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Swastika.Cms.Lib.Services;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Swastika.Cms.Lib.Models.Cms
{
    public partial class SiocCmsContext : DbContext
    {
        public virtual DbSet<SiocArticle> SiocArticle { get; set; }
        public virtual DbSet<SiocArticleMedia> SiocArticleMedia { get; set; }
        public virtual DbSet<SiocArticleModule> SiocArticleModule { get; set; }
        public virtual DbSet<SiocCategory> SiocCategory { get; set; }
        public virtual DbSet<SiocCategoryArticle> SiocCategoryArticle { get; set; }
        public virtual DbSet<SiocCategoryCategory> SiocCategoryCategory { get; set; }
        public virtual DbSet<SiocCategoryModule> SiocCategoryModule { get; set; }
        public virtual DbSet<SiocCategoryPosition> SiocCategoryPosition { get; set; }
        public virtual DbSet<SiocCategoryProduct> SiocCategoryProduct { get; set; }
        public virtual DbSet<SiocCmsUser> SiocCmsUser { get; set; }
        public virtual DbSet<SiocComment> SiocComment { get; set; }
        public virtual DbSet<SiocConfiguration> SiocConfiguration { get; set; }
        public virtual DbSet<SiocCopy> SiocCopy { get; set; }
        public virtual DbSet<SiocCulture> SiocCulture { get; set; }
        public virtual DbSet<SiocCustomer> SiocCustomer { get; set; }
        public virtual DbSet<SiocFile> SiocFile { get; set; }
        public virtual DbSet<SiocLanguage> SiocLanguage { get; set; }
        public virtual DbSet<SiocMedia> SiocMedia { get; set; }
        public virtual DbSet<SiocModule> SiocModule { get; set; }
        public virtual DbSet<SiocModuleArticle> SiocModuleArticle { get; set; }
        public virtual DbSet<SiocModuleAttributeSet> SiocModuleAttributeSet { get; set; }
        public virtual DbSet<SiocModuleAttributeValue> SiocModuleAttributeValue { get; set; }
        public virtual DbSet<SiocModuleData> SiocModuleData { get; set; }
        public virtual DbSet<SiocModuleProduct> SiocModuleProduct { get; set; }
        public virtual DbSet<SiocOrder> SiocOrder { get; set; }
        public virtual DbSet<SiocOrderItem> SiocOrderItem { get; set; }
        public virtual DbSet<SiocParameter> SiocParameter { get; set; }
        public virtual DbSet<SiocPortalPage> SiocPortalPage { get; set; }
        public virtual DbSet<SiocPortalPageNavigation> SiocPortalPageNavigation { get; set; }
        public virtual DbSet<SiocPortalPageRole> SiocPortalPageRole { get; set; }
        public virtual DbSet<SiocPosition> SiocPosition { get; set; }
        public virtual DbSet<SiocProduct> SiocProduct { get; set; }
        public virtual DbSet<SiocProductMedia> SiocProductMedia { get; set; }
        public virtual DbSet<SiocProductModule> SiocProductModule { get; set; }
        public virtual DbSet<SiocRelatedProduct> SiocRelatedProduct { get; set; }
        public virtual DbSet<SiocTemplate> SiocTemplate { get; set; }
        public virtual DbSet<SiocTheme> SiocTheme { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public SiocCmsContext(DbContextOptions<SiocCmsContext> options)
                    : base(options)
        {
        }

        public SiocCmsContext()
        {
        }

        public override int SaveChanges()
        {
            var entities = from e in ChangeTracker.Entries()
                           where e.State == EntityState.Added
                               || e.State == EntityState.Modified
                           select e.Entity;
            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(entity, validationContext);
            }

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entities = from e in ChangeTracker.Entries()
                           where e.State == EntityState.Added
                               || e.State == EntityState.Modified
                           select e.Entity;
            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(entity, validationContext);
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // define the database to use
            string cnn = GlobalConfigurationService.Instance.CmsConfigurations.CmsConnectionString;
            if (!string.IsNullOrEmpty(cnn))
            {
                if (GlobalConfigurationService.Instance.CmsConfigurations.IsSqlite)
                {
                    optionsBuilder.UseSqlite(cnn);
                }
                else
                {
                    optionsBuilder.UseSqlServer(cnn);
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SiocArticle>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Specificulture });

                entity.ToTable("sioc_article");

                entity.HasIndex(e => e.Specificulture);

                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.ExtraProperties).HasColumnType("ntext");

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.SeoDescription).HasMaxLength(4000);

                entity.Property(e => e.SeoKeywords).HasMaxLength(4000);

                entity.Property(e => e.SeoName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SeoTitle).HasMaxLength(4000);

                entity.Property(e => e.Source).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.Tags).HasMaxLength(500);

                entity.Property(e => e.Template).HasMaxLength(250);

                entity.Property(e => e.Thumbnail).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(4000);

                entity.HasOne(d => d.SpecificultureNavigation)
                    .WithMany(p => p.SiocArticle)
                    .HasPrincipalKey(p => p.Specificulture)
                    .HasForeignKey(d => d.Specificulture)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TTS_Article_TTS_Culture");
            });

            modelBuilder.Entity<SiocArticleMedia>(entity =>
            {
                entity.HasKey(e => new { e.MediaId, e.ArticleId, e.Specificulture });

                entity.ToTable("sioc_article_media");

                entity.HasIndex(e => new { e.ArticleId, e.Specificulture });

                entity.HasIndex(e => new { e.MediaId, e.Specificulture });

                entity.Property(e => e.ArticleId).HasMaxLength(50);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.SiocArticle)
                    .WithMany(p => p.SiocArticleMedia)
                    .HasForeignKey(d => new { d.ArticleId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sioc_article_media_sioc_article");

                entity.HasOne(d => d.SiocMedia)
                    .WithMany(p => p.SiocArticleMedia)
                    .HasForeignKey(d => new { d.MediaId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sioc_article_media_sioc_media");
            });

            modelBuilder.Entity<SiocArticleModule>(entity =>
            {
                entity.HasKey(e => new { e.ModuleId, e.ArticleId, e.Specificulture });

                entity.ToTable("sioc_article_module");

                entity.HasIndex(e => new { e.ArticleId, e.Specificulture });

                entity.HasIndex(e => new { e.ModuleId, e.Specificulture });

                entity.Property(e => e.ArticleId).HasMaxLength(50);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

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

            modelBuilder.Entity<SiocCategory>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Specificulture });

                entity.ToTable("sioc_category");

                entity.HasIndex(e => e.Specificulture);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.CssClass).HasMaxLength(50);

                entity.Property(e => e.Icon).HasMaxLength(50);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.Layout).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.SeoDescription).HasMaxLength(4000);

                entity.Property(e => e.SeoKeywords).HasMaxLength(4000);

                entity.Property(e => e.SeoName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SeoTitle).HasMaxLength(4000);

                entity.Property(e => e.StaticUrl).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.Tags).HasMaxLength(500);

                entity.Property(e => e.Template).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(4000);

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

                entity.HasIndex(e => new { e.ArticleId, e.Specificulture });

                entity.HasIndex(e => new { e.CategoryId, e.Specificulture });

                entity.Property(e => e.ArticleId).HasMaxLength(50);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Priority).HasDefaultValueSql("((0))");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

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

                entity.HasIndex(e => new { e.Id, e.Specificulture });

                entity.HasIndex(e => new { e.ParentId, e.Specificulture });

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

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

                entity.HasIndex(e => new { e.CategoryId, e.Specificulture });

                entity.HasIndex(e => new { e.ModuleId, e.Specificulture });

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

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

                entity.HasIndex(e => new { e.CategoryId, e.Specificulture });

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

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

            modelBuilder.Entity<SiocCategoryProduct>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.CategoryId, e.Specificulture });

                entity.ToTable("sioc_category_product");

                entity.HasIndex(e => new { e.CategoryId, e.Specificulture });

                entity.HasIndex(e => new { e.ProductId, e.Specificulture });

                entity.Property(e => e.ProductId).HasMaxLength(50);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.SiocCategory)
                    .WithMany(p => p.SiocCategoryProduct)
                    .HasForeignKey(d => new { d.CategoryId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TTS_Category_Product_TTS_Category");

                entity.HasOne(d => d.SiocProduct)
                    .WithMany(p => p.SiocCategoryProduct)
                    .HasForeignKey(d => new { d.ProductId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TTS_Category_Product_TTS_Product");
            });

            modelBuilder.Entity<SiocCmsUser>(entity =>
            {
                entity.ToTable("sioc_cms_user");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(450);

                entity.Property(e => e.Avatar).HasMaxLength(250);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.Username).HasMaxLength(256);
            });

            modelBuilder.Entity<SiocComment>(entity =>
            {
                entity.ToTable("sioc_comment");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ArticleId).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.FullName).HasMaxLength(250);

                entity.Property(e => e.ProductId).HasMaxLength(50);

                entity.Property(e => e.Rating);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.SiocArticle)
                    .WithMany(p => p.SiocComment)
                    .HasForeignKey(d => new { d.ArticleId, d.Specificulture })
                    .HasConstraintName("FK_sioc_comment_sioc_article");

                entity.HasOne(d => d.SiocOrder)
                    .WithMany(p => p.SiocComment)
                    .HasForeignKey(d => new { d.OrderId, d.Specificulture })
                    .HasConstraintName("FK_sioc_comment_sioc_order");

                entity.HasOne(d => d.SiocProduct)
                    .WithMany(p => p.SiocComment)
                    .HasForeignKey(d => new { d.ProductId, d.Specificulture })
                    .HasConstraintName("FK_sioc_comment_sioc_product");
            });

            modelBuilder.Entity<SiocConfiguration>(entity =>
            {
                entity.HasKey(e => new { e.Keyword, e.Specificulture });

                entity.ToTable("sioc_configuration");

                entity.HasIndex(e => e.Specificulture);

                entity.Property(e => e.Keyword).HasMaxLength(250);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Category).HasMaxLength(250);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

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

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
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

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<SiocCustomer>(entity =>
            {
                entity.ToTable("sioc_customer");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(450);

                entity.Property(e => e.Avatar).HasMaxLength(250);

                entity.Property(e => e.BirthDay).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(250);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UserId).HasMaxLength(256);

                entity.Property(e => e.Username).HasMaxLength(256);
            });

            modelBuilder.Entity<SiocFile>(entity =>
            {
                entity.ToTable("sioc_file");

                entity.HasIndex(e => e.ThemeId);

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Extension)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FileFolder)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FolderType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.ThemeName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Theme)
                    .WithMany(p => p.SiocFile)
                    .HasForeignKey(d => d.ThemeId)
                    .HasConstraintName("FK_sioc_file_sioc_template");
            });

            modelBuilder.Entity<SiocLanguage>(entity =>
            {
                entity.HasKey(e => new { e.Keyword, e.Specificulture });

                entity.ToTable("sioc_language");

                entity.HasIndex(e => e.Specificulture);

                entity.Property(e => e.Keyword).HasMaxLength(250);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Category).HasMaxLength(250);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.SpecificultureNavigation)
                    .WithMany(p => p.SiocLanguage)
                    .HasPrincipalKey(p => p.Specificulture)
                    .HasForeignKey(d => d.Specificulture)
                    .HasConstraintName("FK_Sioc_Language_Sioc_Culture");
            });

            modelBuilder.Entity<SiocMedia>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Specificulture });

                entity.ToTable("sioc_media");

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.Extension)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FileFolder)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FileProperties).HasMaxLength(4000);

                entity.Property(e => e.FileType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.Tags).HasMaxLength(400);

                entity.Property(e => e.Title).HasMaxLength(4000);
            });

            modelBuilder.Entity<SiocModule>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Specificulture });

                entity.ToTable("sioc_module");

                entity.HasIndex(e => e.Specificulture);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.Fields).HasMaxLength(4000);

                entity.Property(e => e.FormTemplate).HasMaxLength(4000);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.Template).HasMaxLength(250);

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

                entity.HasIndex(e => new { e.ArticleId, e.Specificulture });

                entity.HasIndex(e => new { e.ModuleId, e.Specificulture });

                entity.Property(e => e.ArticleId).HasMaxLength(50);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

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

                entity.HasIndex(e => new { e.ModuleId, e.Specificulture });

                entity.HasIndex(e => new { e.ModuleId, e.ArticleId, e.Specificulture });

                entity.HasIndex(e => new { e.ModuleId, e.CategoryId, e.Specificulture });

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.ArticleId).HasMaxLength(50);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Fields)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

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

                entity.HasIndex(e => new { e.AttributeSetId, e.ModuleId, e.Specificulture });

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.DefaultValue)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.HasOne(d => d.SiocModuleAttributeSet)
                    .WithMany(p => p.SiocModuleAttributeValue)
                    .HasForeignKey(d => new { d.AttributeSetId, d.ModuleId, d.Specificulture })
                    .HasConstraintName("FK_sioc_module_attribute_value_sioc_module_attribute_set");
            });

            modelBuilder.Entity<SiocModuleData>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ModuleId, e.Specificulture });

                entity.ToTable("sioc_module_data");

                entity.HasIndex(e => new { e.ModuleId, e.Specificulture });

                entity.HasIndex(e => new { e.ModuleId, e.ArticleId, e.Specificulture });

                entity.HasIndex(e => new { e.ModuleId, e.CategoryId, e.Specificulture });

                entity.HasIndex(e => new { e.ModuleId, e.ProductId, e.Specificulture });

                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.ArticleId).HasMaxLength(50);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Fields)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.ProductId).HasMaxLength(50);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.SiocModule)
                    .WithMany(p => p.SiocModuleData)
                    .HasForeignKey(d => new { d.ModuleId, d.Specificulture })
                    .HasConstraintName("FK_TTS_Module_Data_TTS_Module");

                entity.HasOne(d => d.SiocCategoryModule)
                    .WithMany(p => p.SiocModuleData)
                    .HasForeignKey(d => new { d.ModuleId, d.CategoryId, d.Specificulture })
                    .HasConstraintName("FK_TTS_Module_Data_TTS_Category_Module");

                entity.HasOne(d => d.SiocArticleModule)
                    .WithMany(p => p.SiocModuleData)
                    .HasForeignKey(d => new { d.ModuleId, d.ProductId, d.Specificulture })
                    .HasConstraintName("FK_TTS_Module_Data_TTS_Product_Module");
            });

            modelBuilder.Entity<SiocModuleProduct>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.ModuleId, e.Specificulture });

                entity.ToTable("sioc_module_product");

                entity.HasIndex(e => new { e.ModuleId, e.Specificulture });

                entity.HasIndex(e => new { e.ProductId, e.Specificulture });

                entity.Property(e => e.ProductId).HasMaxLength(50);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.SiocModule)
                    .WithMany(p => p.SiocModuleProduct)
                    .HasForeignKey(d => new { d.ModuleId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TTS_Module_Product_TTS_Module");

                entity.HasOne(d => d.SiocProduct)
                    .WithMany(p => p.SiocModuleProduct)
                    .HasForeignKey(d => new { d.ProductId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TTS_Module_Product_TTS_Product");
            });

            modelBuilder.Entity<SiocOrder>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Specificulture });

                entity.ToTable("sioc_order");

                entity.HasIndex(e => e.Specificulture);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasMaxLength(450);

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.HasOne(d => d.SiocCustomer)
                    .WithMany(p => p.SiocOrder)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_sioc_order_sioc_cms_customer");
            });

            modelBuilder.Entity<SiocOrderItem>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.OrderId, e.Specificulture });

                entity.ToTable("sioc_order_item");

                entity.HasIndex(e => e.Specificulture);

                entity.HasIndex(e => new { e.Id, e.Specificulture })
                    .HasName("AK_sioc_order_item_Id_Specificulture")
                    .IsUnique();

                entity.HasIndex(e => new { e.OrderId, e.Specificulture });

                entity.HasIndex(e => new { e.ProductId, e.Specificulture });

                entity.Property(e => e.ProductId).HasMaxLength(50);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.PriceUnit).HasMaxLength(50);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.SiocOrder)
                    .WithMany(p => p.SiocOrderItem)
                    .HasForeignKey(d => new { d.OrderId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Item_Order");

                entity.HasOne(d => d.SiocProduct)
                    .WithMany(p => p.SiocOrderItem)
                    .HasForeignKey(d => new { d.ProductId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Item_Product");
            });

            modelBuilder.Entity<SiocParameter>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("sioc_parameter");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .ValueGeneratedNever();

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.Value).IsRequired();
            });

            modelBuilder.Entity<SiocPortalPage>(entity =>
            {
                entity.ToTable("sioc_portal_page");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.RouteAction).HasMaxLength(50);

                entity.Property(e => e.RouteName).HasMaxLength(50);

                entity.Property(e => e.RouteValue).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Url).HasMaxLength(250);
            });

            modelBuilder.Entity<SiocPortalPageNavigation>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ParentId });

                entity.ToTable("sioc_portal_page_navigation");

                entity.HasIndex(e => e.ParentId);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.SiocPortalPageNavigationIdNavigation)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sioc_portal_page_navigation_sioc_portal_page");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.SiocPortalPageNavigationParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sioc_portal_page_navigation_sioc_portal_page1");
            });

            modelBuilder.Entity<SiocPortalPageRole>(entity =>
            {
                entity.ToTable("sioc_portal_page_role");

                entity.HasIndex(e => e.PageId);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.SiocPortalPageRole)
                    .HasForeignKey(d => d.PageId)
                    .HasConstraintName("FK_sioc_portal_page_role_sioc_portal_page");
            });

            modelBuilder.Entity<SiocPosition>(entity =>
            {
                entity.ToTable("sioc_position");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<SiocProduct>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Specificulture });

                entity.ToTable("sioc_product");

                entity.HasIndex(e => e.Specificulture);

                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.DealPrice).HasDefaultValueSql("((0))");

                entity.Property(e => e.ExtraProperties).HasColumnType("ntext");

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.Material).HasMaxLength(250);

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.PackageCount).HasDefaultValueSql("((1))");

                entity.Property(e => e.PriceUnit).HasMaxLength(10);

                entity.Property(e => e.SeoDescription).HasMaxLength(4000);

                entity.Property(e => e.SeoKeywords).HasMaxLength(4000);

                entity.Property(e => e.SeoName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SeoTitle).HasMaxLength(4000);

                entity.Property(e => e.Size).HasMaxLength(250);

                entity.Property(e => e.Source).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.Tags).HasMaxLength(500);

                entity.Property(e => e.Template).HasMaxLength(250);

                entity.Property(e => e.Thumbnail).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(4000);

                entity.HasOne(d => d.SpecificultureNavigation)
                    .WithMany(p => p.SiocProduct)
                    .HasPrincipalKey(p => p.Specificulture)
                    .HasForeignKey(d => d.Specificulture)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TTS_Product_TTS_Culture");
            });

            modelBuilder.Entity<SiocProductMedia>(entity =>
            {
                entity.HasKey(e => new { e.MediaId, e.ProductId, e.Specificulture });

                entity.ToTable("sioc_product_media");

                entity.HasIndex(e => new { e.MediaId, e.Specificulture });

                entity.HasIndex(e => new { e.ProductId, e.Specificulture });

                entity.Property(e => e.ProductId).HasMaxLength(50);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.SiocMedia)
                    .WithMany(p => p.SiocProductMedia)
                    .HasForeignKey(d => new { d.MediaId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sioc_product_media_sioc_media");

                entity.HasOne(d => d.SiocProduct)
                    .WithMany(p => p.SiocProductMedia)
                    .HasForeignKey(d => new { d.ProductId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sioc_product_media_sioc_product");
            });

            modelBuilder.Entity<SiocProductModule>(entity =>
            {
                entity.HasKey(e => new { e.ModuleId, e.ProductId, e.Specificulture });

                entity.ToTable("sioc_product_module");

                entity.HasIndex(e => new { e.ModuleId, e.Specificulture });

                entity.HasIndex(e => new { e.ProductId, e.Specificulture });

                entity.Property(e => e.ProductId).HasMaxLength(50);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.SiocModule)
                    .WithMany(p => p.SiocProductModule)
                    .HasForeignKey(d => new { d.ModuleId, d.Specificulture })
                    .HasConstraintName("FK_TTS_Product_Module_TTS_Module1");

                entity.HasOne(d => d.SiocProduct)
                    .WithMany(p => p.SiocProductModule)
                    .HasForeignKey(d => new { d.ProductId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TTS_Product_Module_TTS_Product");
            });

            modelBuilder.Entity<SiocRelatedProduct>(entity =>
            {
                entity.HasKey(e => new { e.SourceProductId, e.RelatedProductId, e.Specificulture });

                entity.ToTable("sioc_related_product");

                entity.HasIndex(e => new { e.RelatedProductId, e.Specificulture });

                entity.HasIndex(e => new { e.SourceProductId, e.Specificulture });

                entity.Property(e => e.SourceProductId).HasMaxLength(50);

                entity.Property(e => e.RelatedProductId).HasMaxLength(50);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.SiocProduct)
                    .WithMany(p => p.SiocRelatedProductSiocProduct)
                    .HasForeignKey(d => new { d.RelatedProductId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sioc_related_product_sioc_product1");

                entity.HasOne(d => d.S)
                    .WithMany(p => p.SiocRelatedProductS)
                    .HasForeignKey(d => new { d.SourceProductId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sioc_related_product_sioc_product");
            });

            modelBuilder.Entity<SiocTemplate>(entity =>
            {
                entity.ToTable("sioc_template");

                entity.HasIndex(e => e.TemplateId)
                    .HasName("IX_sioc_template_file_TemplateId");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Extension)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FileFolder)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FolderType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.MobileContent).HasColumnType("ntext");

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.Scripts).HasColumnType("ntext");

                entity.Property(e => e.SpaContent).HasColumnType("ntext");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.Styles).HasColumnType("ntext");

                entity.Property(e => e.TemplateName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.SiocTemplate)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sioc_template_file_sioc_template");
            });

            modelBuilder.Entity<SiocTheme>(entity =>
            {
                entity.ToTable("sioc_theme");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.PreviewUrl).HasMaxLength(450);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });
        }
    }
}
