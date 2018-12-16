using Microsoft.EntityFrameworkCore;
using Sio.Cms.Lib.Services;

namespace Sio.Cms.Lib.Models.Cms
{
    public partial class SioCmsContext : DbContext
    {
        public virtual DbSet<SioArticle> SioArticle { get; set; }
        public virtual DbSet<SioArticleMedia> SioArticleMedia { get; set; }
        public virtual DbSet<SioArticleModule> SioArticleModule { get; set; }
        public virtual DbSet<SioCmsUser> SioCmsUser { get; set; }
        public virtual DbSet<SioComment> SioComment { get; set; }
        public virtual DbSet<SioConfiguration> SioConfiguration { get; set; }
        public virtual DbSet<SioCopy> SioCopy { get; set; }
        public virtual DbSet<SioCulture> SioCulture { get; set; }
        public virtual DbSet<SioCustomer> SioCustomer { get; set; }
        public virtual DbSet<SioFile> SioFile { get; set; }
        public virtual DbSet<SioLanguage> SioLanguage { get; set; }
        public virtual DbSet<SioMedia> SioMedia { get; set; }
        public virtual DbSet<SioModule> SioModule { get; set; }
        public virtual DbSet<SioModuleArticle> SioModuleArticle { get; set; }
        public virtual DbSet<SioModuleAttributeSet> SioModuleAttributeSet { get; set; }
        public virtual DbSet<SioModuleAttributeValue> SioModuleAttributeValue { get; set; }
        public virtual DbSet<SioModuleData> SioModuleData { get; set; }
        public virtual DbSet<SioModuleProduct> SioModuleProduct { get; set; }
        public virtual DbSet<SioOrder> SioOrder { get; set; }
        public virtual DbSet<SioOrderItem> SioOrderItem { get; set; }
        public virtual DbSet<SioPage> SioPage { get; set; }
        public virtual DbSet<SioPageArticle> SioPageArticle { get; set; }
        public virtual DbSet<SioPageModule> SioPageModule { get; set; }
        public virtual DbSet<SioPagePage> SioPagePage { get; set; }
        public virtual DbSet<SioPagePosition> SioPagePosition { get; set; }
        public virtual DbSet<SioPageProduct> SioPageProduct { get; set; }
        public virtual DbSet<SioParameter> SioParameter { get; set; }
        public virtual DbSet<SioPortalPage> SioPortalPage { get; set; }
        public virtual DbSet<SioPortalPageNavigation> SioPortalPageNavigation { get; set; }
        public virtual DbSet<SioPortalPagePosition> SioPortalPagePosition { get; set; }
        public virtual DbSet<SioPortalPageRole> SioPortalPageRole { get; set; }
        public virtual DbSet<SioPosition> SioPosition { get; set; }
        public virtual DbSet<SioProduct> SioProduct { get; set; }
        public virtual DbSet<SioProductMedia> SioProductMedia { get; set; }
        public virtual DbSet<SioProductModule> SioProductModule { get; set; }
        public virtual DbSet<SioRelatedArticle> SioRelatedArticle { get; set; }
        public virtual DbSet<SioRelatedProduct> SioRelatedProduct { get; set; }
        public virtual DbSet<SioSetAttribute> SioSetAttribute { get; set; }
        public virtual DbSet<SioTemplate> SioTemplate { get; set; }
        public virtual DbSet<SioTheme> SioTheme { get; set; }
        public virtual DbSet<SioUrlAlias> SioUrlAlias { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public SioCmsContext(DbContextOptions<SioCmsContext> options)
                    : base(options)
        {
        }
        public SioCmsContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //define the database to use
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SioArticle>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Specificulture });

                entity.ToTable("sio_article");

                entity.HasIndex(e => e.SetAttributeId);

                entity.HasIndex(e => e.Specificulture);

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

                entity.Property(e => e.SetAttributeData).HasColumnType("ntext");

                entity.Property(e => e.Source).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.Tags).HasMaxLength(500);

                entity.Property(e => e.Template).HasMaxLength(250);

                entity.Property(e => e.Thumbnail).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(4000);

                entity.HasOne(d => d.SetAttribute)
                    .WithMany(p => p.SioArticle)
                    .HasForeignKey(d => d.SetAttributeId)
                    .HasConstraintName("FK_sio_article_sio_set_attribute");

                entity.HasOne(d => d.SpecificultureNavigation)
                    .WithMany(p => p.SioArticle)
                    .HasPrincipalKey(p => p.Specificulture)
                    .HasForeignKey(d => d.Specificulture)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sio_Article_Sio_Culture");
            });

            modelBuilder.Entity<SioArticleMedia>(entity =>
            {
                entity.HasKey(e => new { e.MediaId, e.ArticleId, e.Specificulture });

                entity.ToTable("sio_article_media");

                entity.HasIndex(e => new { e.ArticleId, e.Specificulture });

                entity.HasIndex(e => new { e.MediaId, e.Specificulture });

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.SioArticle)
                    .WithMany(p => p.SioArticleMedia)
                    .HasForeignKey(d => new { d.ArticleId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sio_article_media_sio_article");

                entity.HasOne(d => d.SioMedia)
                    .WithMany(p => p.SioArticleMedia)
                    .HasForeignKey(d => new { d.MediaId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sio_article_media_sio_media");
            });

            modelBuilder.Entity<SioArticleModule>(entity =>
            {
                entity.HasKey(e => new { e.ModuleId, e.ArticleId, e.Specificulture });

                entity.ToTable("sio_article_module");

                entity.HasIndex(e => new { e.ArticleId, e.Specificulture });

                entity.HasIndex(e => new { e.ModuleId, e.Specificulture });

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.SioArticle)
                    .WithMany(p => p.SioArticleModule)
                    .HasForeignKey(d => new { d.ArticleId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sio_Article_Module_Sio_Article");

                entity.HasOne(d => d.SioModule)
                    .WithMany(p => p.SioArticleModule)
                    .HasForeignKey(d => new { d.ModuleId, d.Specificulture })
                    .HasConstraintName("FK_Sio_Article_Module_Sio_Module1");
            });

            modelBuilder.Entity<SioCmsUser>(entity =>
            {
                entity.ToTable("sio_cms_user");

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

            modelBuilder.Entity<SioComment>(entity =>
            {
                entity.ToTable("sio_comment");

                entity.HasIndex(e => new { e.ArticleId, e.Specificulture });

                entity.HasIndex(e => new { e.OrderId, e.Specificulture });

                entity.HasIndex(e => new { e.ProductId, e.Specificulture });

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.FullName).HasMaxLength(250);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.SioArticle)
                    .WithMany(p => p.SioComment)
                    .HasForeignKey(d => new { d.ArticleId, d.Specificulture })
                    .HasConstraintName("FK_sio_comment_sio_article");

                entity.HasOne(d => d.SioOrder)
                    .WithMany(p => p.SioComment)
                    .HasForeignKey(d => new { d.OrderId, d.Specificulture })
                    .HasConstraintName("FK_sio_comment_sio_order");

                entity.HasOne(d => d.SioProduct)
                    .WithMany(p => p.SioComment)
                    .HasForeignKey(d => new { d.ProductId, d.Specificulture })
                    .HasConstraintName("FK_sio_comment_sio_product");
            });

            modelBuilder.Entity<SioConfiguration>(entity =>
            {
                entity.HasKey(e => new { e.Keyword, e.Specificulture });

                entity.ToTable("sio_configuration");

                entity.HasIndex(e => e.Specificulture);

                entity.Property(e => e.Keyword).HasMaxLength(250);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Category).HasMaxLength(250);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.SpecificultureNavigation)
                    .WithMany(p => p.SioConfiguration)
                    .HasPrincipalKey(p => p.Specificulture)
                    .HasForeignKey(d => d.Specificulture)
                    .HasConstraintName("FK_Sio_Configuration_Sio_Culture");
            });

            modelBuilder.Entity<SioCopy>(entity =>
            {
                entity.HasKey(e => new { e.Culture, e.Keyword });

                entity.ToTable("sio_copy");

                entity.Property(e => e.Culture).HasMaxLength(10);

                entity.Property(e => e.Keyword).HasMaxLength(250);

                entity.Property(e => e.Note).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<SioCulture>(entity =>
            {
                entity.ToTable("sio_culture");

                entity.HasIndex(e => e.Specificulture)
                    .HasName("IX_Sio_Culture")
                    .IsUnique();

                entity.Property(e => e.Alias).HasMaxLength(150);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

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

            modelBuilder.Entity<SioCustomer>(entity =>
            {
                entity.ToTable("sio_customer");

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

            modelBuilder.Entity<SioFile>(entity =>
            {
                entity.ToTable("sio_file");

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
                    .WithMany(p => p.SioFile)
                    .HasForeignKey(d => d.ThemeId)
                    .HasConstraintName("FK_sio_file_sio_template");
            });

            modelBuilder.Entity<SioLanguage>(entity =>
            {
                entity.HasKey(e => new { e.Keyword, e.Specificulture });

                entity.ToTable("sio_language");

                entity.HasIndex(e => e.Specificulture);

                entity.Property(e => e.Keyword).HasMaxLength(250);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Category).HasMaxLength(250);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DefaultValue).HasMaxLength(250);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.SpecificultureNavigation)
                    .WithMany(p => p.SioLanguage)
                    .HasPrincipalKey(p => p.Specificulture)
                    .HasForeignKey(d => d.Specificulture)
                    .HasConstraintName("FK_Sio_Language_Sio_Culture");
            });

            modelBuilder.Entity<SioMedia>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Specificulture });

                entity.ToTable("sio_media");

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

            modelBuilder.Entity<SioModule>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Specificulture });

                entity.ToTable("sio_module");

                entity.HasIndex(e => e.Specificulture);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

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
                    .WithMany(p => p.SioModule)
                    .HasPrincipalKey(p => p.Specificulture)
                    .HasForeignKey(d => d.Specificulture)
                    .HasConstraintName("FK_Sio_Module_Sio_Culture");
            });

            modelBuilder.Entity<SioModuleArticle>(entity =>
            {
                entity.HasKey(e => new { e.ArticleId, e.ModuleId, e.Specificulture });

                entity.ToTable("sio_module_article");

                entity.HasIndex(e => new { e.ArticleId, e.Specificulture });

                entity.HasIndex(e => new { e.ModuleId, e.Specificulture });

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.SioArticle)
                    .WithMany(p => p.SioModuleArticle)
                    .HasForeignKey(d => new { d.ArticleId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sio_Module_Article_Sio_Article");

                entity.HasOne(d => d.SioModule)
                    .WithMany(p => p.SioModuleArticle)
                    .HasForeignKey(d => new { d.ModuleId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sio_Module_Article_Sio_Module");
            });

            modelBuilder.Entity<SioModuleAttributeSet>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ModuleId, e.Specificulture });

                entity.ToTable("sio_module_attribute_set");

                entity.HasIndex(e => new { e.ModuleId, e.Specificulture });

                entity.HasIndex(e => new { e.ModuleId, e.ArticleId, e.Specificulture });

                entity.HasIndex(e => new { e.ModuleId, e.CategoryId, e.Specificulture })
                    .HasName("IX_sio_module_attribute_set_ModuleId_PageId_Specificulture");

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Fields)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.SioModule)
                    .WithMany(p => p.SioModuleAttributeSet)
                    .HasForeignKey(d => new { d.ModuleId, d.Specificulture })
                    .HasConstraintName("FK_Sio_Module_Attribute_set_Sio_Module");

                entity.HasOne(d => d.SioArticleModule)
                    .WithMany(p => p.SioModuleAttributeSet)
                    .HasForeignKey(d => new { d.ModuleId, d.ArticleId, d.Specificulture })
                    .HasConstraintName("FK_Sio_Module_Attribute_set_Sio_Article_Module");

                entity.HasOne(d => d.SioPageModule)
                    .WithMany(p => p.SioModuleAttributeSet)
                    .HasForeignKey(d => new { d.ModuleId, d.CategoryId, d.Specificulture })
                    .HasConstraintName("FK_Sio_Module_Attribute_set_Sio_Page_Module");
            });

            modelBuilder.Entity<SioModuleAttributeValue>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.AttributeSetId, e.Specificulture });

                entity.ToTable("sio_module_attribute_value");

                entity.HasIndex(e => new { e.AttributeSetId, e.ModuleId, e.Specificulture });

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.DefaultValue)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.HasOne(d => d.SioModuleAttributeSet)
                    .WithMany(p => p.SioModuleAttributeValue)
                    .HasForeignKey(d => new { d.AttributeSetId, d.ModuleId, d.Specificulture })
                    .HasConstraintName("FK_sio_module_attribute_value_sio_module_attribute_set");
            });

            modelBuilder.Entity<SioModuleData>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ModuleId, e.Specificulture });

                entity.ToTable("sio_module_data");

                entity.HasIndex(e => new { e.ModuleId, e.Specificulture });

                entity.HasIndex(e => new { e.ModuleId, e.ArticleId, e.Specificulture });

                entity.HasIndex(e => new { e.ModuleId, e.CategoryId, e.Specificulture })
                    .HasName("IX_sio_module_data_ModuleId_PageId_Specificulture");

                entity.HasIndex(e => new { e.ModuleId, e.ProductId, e.Specificulture });

                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Fields)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.SioModule)
                    .WithMany(p => p.SioModuleData)
                    .HasForeignKey(d => new { d.ModuleId, d.Specificulture })
                    .HasConstraintName("FK_Sio_Module_Data_Sio_Module");

                entity.HasOne(d => d.SioPageModule)
                    .WithMany(p => p.SioModuleData)
                    .HasForeignKey(d => new { d.ModuleId, d.CategoryId, d.Specificulture })
                    .HasConstraintName("FK_Sio_Module_Data_Sio_Page_Module");

                entity.HasOne(d => d.SioArticleModule)
                    .WithMany(p => p.SioModuleData)
                    .HasForeignKey(d => new { d.ModuleId, d.ProductId, d.Specificulture })
                    .HasConstraintName("FK_Sio_Module_Data_Sio_Product_Module");
            });

            modelBuilder.Entity<SioModuleProduct>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.ModuleId, e.Specificulture });

                entity.ToTable("sio_module_product");

                entity.HasIndex(e => new { e.ModuleId, e.Specificulture });

                entity.HasIndex(e => new { e.ProductId, e.Specificulture });

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.SioModule)
                    .WithMany(p => p.SioModuleProduct)
                    .HasForeignKey(d => new { d.ModuleId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sio_Module_Product_Sio_Module");

                entity.HasOne(d => d.SioProduct)
                    .WithMany(p => p.SioModuleProduct)
                    .HasForeignKey(d => new { d.ProductId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sio_Module_Product_Sio_Product");
            });

            modelBuilder.Entity<SioOrder>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Specificulture });

                entity.ToTable("sio_order");

                entity.HasIndex(e => e.CustomerId);

                entity.HasIndex(e => e.Specificulture);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SioOrder)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_sio_order_sio_cms_customer");
            });

            modelBuilder.Entity<SioOrderItem>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.OrderId, e.Specificulture });

                entity.ToTable("sio_order_item");

                entity.HasIndex(e => e.Specificulture);

                entity.HasIndex(e => new { e.Id, e.Specificulture })
                    .HasName("AK_sio_order_item_Id_Specificulture")
                    .IsUnique();

                entity.HasIndex(e => new { e.OrderId, e.Specificulture });

                entity.HasIndex(e => new { e.ProductId, e.Specificulture });

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.PriceUnit).HasMaxLength(50);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.SioOrder)
                    .WithMany(p => p.SioOrderItem)
                    .HasForeignKey(d => new { d.OrderId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Item_Order");

                entity.HasOne(d => d.SioProduct)
                    .WithMany(p => p.SioOrderItem)
                    .HasForeignKey(d => new { d.ProductId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Item_Product");
            });

            modelBuilder.Entity<SioPage>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Specificulture });

                entity.ToTable("sio_page");

                entity.HasIndex(e => e.SetAttributeId);

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

                entity.Property(e => e.SetAttributeData).HasColumnType("ntext");

                entity.Property(e => e.StaticUrl).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.Tags).HasMaxLength(500);

                entity.Property(e => e.Template).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(4000);

                entity.HasOne(d => d.SetAttribute)
                    .WithMany(p => p.SioPage)
                    .HasForeignKey(d => d.SetAttributeId)
                    .HasConstraintName("FK_sio_page_sio_set_attribute");

                entity.HasOne(d => d.SpecificultureNavigation)
                    .WithMany(p => p.SioPage)
                    .HasPrincipalKey(p => p.Specificulture)
                    .HasForeignKey(d => d.Specificulture)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sio_Page_Sio_Culture");
            });

            modelBuilder.Entity<SioPageArticle>(entity =>
            {
                entity.HasKey(e => new { e.ArticleId, e.CategoryId, e.Specificulture });

                entity.ToTable("sio_page_article");

                entity.HasIndex(e => new { e.ArticleId, e.Specificulture });

                entity.HasIndex(e => new { e.CategoryId, e.Specificulture })
                    .HasName("IX_sio_page_article_PageId_Specificulture");

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Priority).HasDefaultValueSql("((0))");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.SioArticle)
                    .WithMany(p => p.SioPageArticle)
                    .HasForeignKey(d => new { d.ArticleId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sio_Page_Article_Sio_Article");

                entity.HasOne(d => d.SioPage)
                    .WithMany(p => p.SioPageArticle)
                    .HasForeignKey(d => new { d.CategoryId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sio_Page_Article_Sio_Page");
            });

            modelBuilder.Entity<SioPageModule>(entity =>
            {
                entity.HasKey(e => new { e.ModuleId, e.CategoryId, e.Specificulture });

                entity.ToTable("sio_page_module");

                entity.HasIndex(e => new { e.CategoryId, e.Specificulture })
                    .HasName("IX_sio_page_module_PageId_Specificulture");

                entity.HasIndex(e => new { e.ModuleId, e.Specificulture });

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.SioPage)
                    .WithMany(p => p.SioPageModule)
                    .HasForeignKey(d => new { d.CategoryId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sio_Page_Module_Sio_Page");

                entity.HasOne(d => d.SioModule)
                    .WithMany(p => p.SioPageModule)
                    .HasForeignKey(d => new { d.ModuleId, d.Specificulture })
                    .HasConstraintName("FK_Sio_Menu_Module_Sio_Module1");
            });

            modelBuilder.Entity<SioPagePage>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ParentId, e.Specificulture });

                entity.ToTable("sio_page_page");

                entity.HasIndex(e => new { e.Id, e.Specificulture });

                entity.HasIndex(e => new { e.ParentId, e.Specificulture });

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.SioPage)
                    .WithMany(p => p.SioPagePageSioPage)
                    .HasForeignKey(d => new { d.Id, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sio_Page_Page_Sio_Page");

                entity.HasOne(d => d.SioPageNavigation)
                    .WithMany(p => p.SioPagePageSioPageNavigation)
                    .HasForeignKey(d => new { d.ParentId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sio_Page_Page_Sio_Page1");
            });

            modelBuilder.Entity<SioPagePosition>(entity =>
            {
                entity.HasKey(e => new { e.PositionId, e.CategoryId, e.Specificulture });

                entity.ToTable("sio_page_position");

                entity.HasIndex(e => new { e.CategoryId, e.Specificulture })
                    .HasName("IX_sio_page_position_PageId_Specificulture");

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.SioPagePosition)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_Sio_Page_Position_Sio_Position");

                entity.HasOne(d => d.SioPage)
                    .WithMany(p => p.SioPagePosition)
                    .HasForeignKey(d => new { d.CategoryId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sio_Page_Position_Sio_Page");
            });

            modelBuilder.Entity<SioPageProduct>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.CategoryId, e.Specificulture });

                entity.ToTable("sio_page_product");

                entity.HasIndex(e => new { e.CategoryId, e.Specificulture })
                    .HasName("IX_sio_page_product_PageId_Specificulture");

                entity.HasIndex(e => new { e.ProductId, e.Specificulture });

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.SioPage)
                    .WithMany(p => p.SioPageProduct)
                    .HasForeignKey(d => new { d.CategoryId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sio_Page_Product_Sio_Page");

                entity.HasOne(d => d.SioProduct)
                    .WithMany(p => p.SioPageProduct)
                    .HasForeignKey(d => new { d.ProductId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sio_Page_Product_Sio_Product");
            });

            modelBuilder.Entity<SioParameter>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("sio_parameter");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .ValueGeneratedNever();

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.Value).IsRequired();
            });

            modelBuilder.Entity<SioPortalPage>(entity =>
            {
                entity.ToTable("sio_portal_page");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(450);

                entity.Property(e => e.Icon).HasMaxLength(50);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.TextDefault).HasMaxLength(250);

                entity.Property(e => e.TextKeyword).HasMaxLength(250);

                entity.Property(e => e.Url).HasMaxLength(250);
            });

            modelBuilder.Entity<SioPortalPageNavigation>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ParentId });

                entity.ToTable("sio_portal_page_navigation");

                entity.HasIndex(e => e.ParentId);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.SioPortalPageNavigationIdNavigation)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sio_portal_page_navigation_sio_portal_page");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.SioPortalPageNavigationParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sio_portal_page_navigation_sio_portal_page1");
            });

            modelBuilder.Entity<SioPortalPagePosition>(entity =>
            {
                entity.HasKey(e => new { e.PositionId, e.PortalPageId });

                entity.ToTable("sio_portal_page_position");

                entity.HasIndex(e => e.PortalPageId);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.PortalPage)
                    .WithMany(p => p.SioPortalPagePosition)
                    .HasForeignKey(d => d.PortalPageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sio_PortalPage_Position_Sio_PortalPage");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.SioPortalPagePosition)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_Sio_PortalPage_Position_Sio_Position");
            });

            modelBuilder.Entity<SioPortalPageRole>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.PageId });

                entity.ToTable("sio_portal_page_role");

                entity.HasIndex(e => e.PageId);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.SioPortalPageRole)
                    .HasForeignKey(d => d.PageId)
                    .HasConstraintName("FK_sio_portal_page_role_sio_portal_page");
            });

            modelBuilder.Entity<SioPosition>(entity =>
            {
                entity.ToTable("sio_position");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<SioProduct>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Specificulture });

                entity.ToTable("sio_product");

                entity.HasIndex(e => e.SetAttributeId);

                entity.HasIndex(e => e.Specificulture);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Code)
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

                entity.Property(e => e.PrivacyId).HasMaxLength(10);

                entity.Property(e => e.SeoDescription).HasMaxLength(4000);

                entity.Property(e => e.SeoKeywords).HasMaxLength(4000);

                entity.Property(e => e.SeoName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SeoTitle).HasMaxLength(4000);

                entity.Property(e => e.SetAttributeData).HasColumnType("ntext");

                entity.Property(e => e.Source).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.Tags).HasMaxLength(500);

                entity.Property(e => e.Template).HasMaxLength(250);

                entity.Property(e => e.Thumbnail).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(4000);

                entity.Property(e => e.Unit).HasMaxLength(50);

                entity.HasOne(d => d.SetAttribute)
                    .WithMany(p => p.SioProduct)
                    .HasForeignKey(d => d.SetAttributeId)
                    .HasConstraintName("FK_sio_product_sio_set_attribute");

                entity.HasOne(d => d.SpecificultureNavigation)
                    .WithMany(p => p.SioProduct)
                    .HasPrincipalKey(p => p.Specificulture)
                    .HasForeignKey(d => d.Specificulture)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sio_Product_Sio_Culture");
            });

            modelBuilder.Entity<SioProductMedia>(entity =>
            {
                entity.HasKey(e => new { e.MediaId, e.ProductId, e.Specificulture });

                entity.ToTable("sio_product_media");

                entity.HasIndex(e => new { e.MediaId, e.Specificulture });

                entity.HasIndex(e => new { e.ProductId, e.Specificulture });

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.SioMedia)
                    .WithMany(p => p.SioProductMedia)
                    .HasForeignKey(d => new { d.MediaId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sio_product_media_sio_media");

                entity.HasOne(d => d.SioProduct)
                    .WithMany(p => p.SioProductMedia)
                    .HasForeignKey(d => new { d.ProductId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sio_product_media_sio_product");
            });

            modelBuilder.Entity<SioProductModule>(entity =>
            {
                entity.HasKey(e => new { e.ModuleId, e.ProductId, e.Specificulture });

                entity.ToTable("sio_product_module");

                entity.HasIndex(e => new { e.ModuleId, e.Specificulture });

                entity.HasIndex(e => new { e.ProductId, e.Specificulture });

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.SioModule)
                    .WithMany(p => p.SioProductModule)
                    .HasForeignKey(d => new { d.ModuleId, d.Specificulture })
                    .HasConstraintName("FK_Sio_Product_Module_Sio_Module1");

                entity.HasOne(d => d.SioProduct)
                    .WithMany(p => p.SioProductModule)
                    .HasForeignKey(d => new { d.ProductId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sio_Product_Module_Sio_Product");
            });

            modelBuilder.Entity<SioRelatedArticle>(entity =>
            {
                entity.HasKey(e => new { e.SourceId, e.DestinationId, e.Specificulture });

                entity.ToTable("sio_related_article");

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(450);

                entity.Property(e => e.Image).HasMaxLength(450);

                entity.HasOne(d => d.SioArticle)
                    .WithMany(p => p.SioRelatedArticleSioArticle)
                    .HasForeignKey(d => new { d.DestinationId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sio_related_article_sio_article1");

                entity.HasOne(d => d.S)
                    .WithMany(p => p.SioRelatedArticleS)
                    .HasForeignKey(d => new { d.SourceId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sio_related_article_sio_article");
            });

            modelBuilder.Entity<SioRelatedProduct>(entity =>
            {
                entity.HasKey(e => new { e.SourceId, e.DestinationId, e.Specificulture });

                entity.ToTable("sio_related_product");

                entity.HasIndex(e => new { e.DestinationId, e.Specificulture });

                entity.HasIndex(e => new { e.SourceId, e.Specificulture });

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(450);

                entity.Property(e => e.Image).HasMaxLength(450);

                entity.HasOne(d => d.SioProduct)
                    .WithMany(p => p.SioRelatedProductSioProduct)
                    .HasForeignKey(d => new { d.DestinationId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sio_related_product_sio_product1");

                entity.HasOne(d => d.S)
                    .WithMany(p => p.SioRelatedProductS)
                    .HasForeignKey(d => new { d.SourceId, d.Specificulture })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sio_related_product_sio_product");
            });

            modelBuilder.Entity<SioSetAttribute>(entity =>
            {
                entity.ToTable("sio_set_attribute");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(350);

                entity.Property(e => e.Fields).IsRequired();

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<SioTemplate>(entity =>
            {
                entity.ToTable("sio_template");

                entity.HasIndex(e => e.ThemeId)
                    .HasName("IX_sio_template_file_TemplateId");

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

                entity.Property(e => e.ThemeName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Theme)
                    .WithMany(p => p.SioTemplate)
                    .HasForeignKey(d => d.ThemeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sio_template_sio_theme");
            });

            modelBuilder.Entity<SioTheme>(entity =>
            {
                entity.ToTable("sio_theme");

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

            modelBuilder.Entity<SioUrlAlias>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Specificulture });

                entity.ToTable("sio_url_alias");

                entity.HasIndex(e => e.Specificulture);

                entity.Property(e => e.Specificulture).HasMaxLength(10);

                entity.Property(e => e.Alias).HasMaxLength(250);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.SourceId).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.Type).HasDefaultValueSql("('0')");

                entity.HasOne(d => d.SpecificultureNavigation)
                    .WithMany(p => p.SioUrlAlias)
                    .HasPrincipalKey(p => p.Specificulture)
                    .HasForeignKey(d => d.Specificulture)
                    .HasConstraintName("FK_Sio_Url_Alias_Sio_Culture");
            });
        }
    }
}
