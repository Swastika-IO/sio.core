using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Swastika.Crm.Lib.Models.Crm
{
    public partial class SwastikaCrmContext : DbContext
    {
        public virtual DbSet<CrmAddress> CrmAddress { get; set; }
        public virtual DbSet<CrmCategory> CrmCategory { get; set; }
        public virtual DbSet<CrmCustomer> CrmCustomer { get; set; }
        public virtual DbSet<CrmEmployee> CrmEmployee { get; set; }
        public virtual DbSet<CrmFund> CrmFund { get; set; }
        public virtual DbSet<CrmMenu> CrmMenu { get; set; }
        public virtual DbSet<CrmProduct> CrmProduct { get; set; }
        public virtual DbSet<CrmProductDetailsTemplate> CrmProductDetailsTemplate { get; set; }
        public virtual DbSet<CrmProductProperty> CrmProductProperty { get; set; }
        public virtual DbSet<CrmProvider> CrmProvider { get; set; }
        public virtual DbSet<CrmReceiptDelivery> CrmReceiptDelivery { get; set; }
        public virtual DbSet<CrmReceiptDetails> CrmReceiptDetails { get; set; }
        public virtual DbSet<CrmReceiptImport> CrmReceiptImport { get; set; }
        public virtual DbSet<CrmReceiptReturn> CrmReceiptReturn { get; set; }
        public virtual DbSet<CrmRoleMenu> CrmRoleMenu { get; set; }
        public virtual DbSet<CrmTags> CrmTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=115.77.190.113,4444;Database=sw_crm_structure;UID=sa;Pwd=sqlP@ssw0rd;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CrmAddress>(entity =>
            {
                entity.HasKey(e => e.AddressId);

                entity.ToTable("CRM_Address");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.City).HasMaxLength(250);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ProviderId).HasColumnName("ProviderID");

                entity.Property(e => e.State).HasMaxLength(250);

                entity.Property(e => e.Street).HasMaxLength(250);

                entity.Property(e => e.Zip).HasColumnType("nchar(10)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CrmAddress)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CRM_Address_CRM_Customer");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.CrmAddress)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_CRM_Address_CRM_Employee");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.CrmAddress)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("FK_CRM_Address_CRM_Provider");
            });

            modelBuilder.Entity<CrmCategory>(entity =>
            {
                entity.ToTable("CRM_Category");

                entity.Property(e => e.Order).HasDefaultValueSql("((0))");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<CrmCustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("CRM_Customer");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Avatar).HasMaxLength(250);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<CrmEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("CRM_Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Avatar).HasMaxLength(250);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.IdcardNumber)
                    .HasColumnName("IDCardNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.PhoneNumber).HasMaxLength(250);

                entity.Property(e => e.Position).HasMaxLength(50);

                entity.Property(e => e.ProfileFilePath).HasMaxLength(100);
            });

            modelBuilder.Entity<CrmFund>(entity =>
            {
                entity.ToTable("CRM_Fund");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Payer)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Receiver).HasMaxLength(250);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CrmMenu>(entity =>
            {
                entity.ToTable("CRM_Menu");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Icon).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Order).HasDefaultValueSql("((0))");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Path).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<CrmProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("CRM_Product");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DealPrice).HasDefaultValueSql("((0))");

                entity.Property(e => e.Discount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.ImportPrice).HasDefaultValueSql("((0))");

                entity.Property(e => e.Infos).HasColumnType("ntext");

                entity.Property(e => e.IsVisible).HasDefaultValueSql("((1))");

                entity.Property(e => e.Language)
                    .HasColumnType("nchar(10)")
                    .HasDefaultValueSql("(N'vn')");

                entity.Property(e => e.Material).HasMaxLength(250);

                entity.Property(e => e.NormalPrice).HasDefaultValueSql("((0))");

                entity.Property(e => e.PackageCount).HasDefaultValueSql("((1))");

                entity.Property(e => e.Size).HasMaxLength(250);

                entity.Property(e => e.Source).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(4000);

                entity.Property(e => e.TotalImported).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalRemain).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalSaled).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<CrmProductDetailsTemplate>(entity =>
            {
                entity.ToTable("CRM_Product_Details_Template");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CateId).HasColumnName("CateID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Template).IsRequired();
            });

            modelBuilder.Entity<CrmProductProperty>(entity =>
            {
                entity.HasKey(e => e.PropertyId);

                entity.ToTable("CRM_Product_Property");

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Roles)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CrmProductProperty)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CRM_Product_Property_CRM_Products");
            });

            modelBuilder.Entity<CrmProvider>(entity =>
            {
                entity.HasKey(e => e.ProviderId);

                entity.ToTable("CRM_Provider");

                entity.Property(e => e.ProviderId).HasColumnName("ProviderID");

                entity.Property(e => e.Avatar).HasMaxLength(250);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<CrmReceiptDelivery>(entity =>
            {
                entity.HasKey(e => e.ReceiptId);

                entity.ToTable("CRM_Receipt_Delivery");

                entity.Property(e => e.ReceiptId).HasColumnName("ReceiptID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FormPayment).HasMaxLength(250);

                entity.Property(e => e.Note).HasMaxLength(250);

                entity.Property(e => e.OrderPhone).HasMaxLength(50);

                entity.Property(e => e.ReceivePhone).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(250);

                entity.Property(e => e.TotalAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalPaid).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalPaidBanking).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalReduceAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalRemain).HasDefaultValueSql("((0))");

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CrmReceiptDelivery)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CRM_Receipt_Delivery_CRM_Customer");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.CrmReceiptDelivery)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_CRM_Receipt_Delivery_CRM_Employee");
            });

            modelBuilder.Entity<CrmReceiptDetails>(entity =>
            {
                entity.HasKey(e => e.ReceiptDetailsId);

                entity.ToTable("CRM_Receipt_Details");

                entity.Property(e => e.ReceiptDetailsId).HasColumnName("ReceiptDetailsID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FinalPrice).HasDefaultValueSql("((0))");

                entity.Property(e => e.Note).HasMaxLength(250);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.QuantityPackage).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceiptDeliveryId).HasColumnName("ReceiptDeliveryID");

                entity.Property(e => e.ReceiptImportId).HasColumnName("ReceiptImportID");

                entity.Property(e => e.ReceiptReturnId).HasColumnName("ReceiptReturnID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CrmReceiptDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CRM_Receipt_Details_CRM_Product");

                entity.HasOne(d => d.ReceiptDelivery)
                    .WithMany(p => p.CrmReceiptDetails)
                    .HasForeignKey(d => d.ReceiptDeliveryId)
                    .HasConstraintName("FK_CRM_Receipt_Details_CRM_Receipt_Delivery");

                entity.HasOne(d => d.ReceiptImport)
                    .WithMany(p => p.CrmReceiptDetails)
                    .HasForeignKey(d => d.ReceiptImportId)
                    .HasConstraintName("FK_CRM_Receipt_Details_CRM_Receipt_Import");

                entity.HasOne(d => d.ReceiptReturn)
                    .WithMany(p => p.CrmReceiptDetails)
                    .HasForeignKey(d => d.ReceiptReturnId)
                    .HasConstraintName("FK_CRM_Receipt_Details_CRM_Receipt_Return");
            });

            modelBuilder.Entity<CrmReceiptImport>(entity =>
            {
                entity.HasKey(e => e.ReceiptId);

                entity.ToTable("CRM_Receipt_Import");

                entity.Property(e => e.ReceiptId).HasColumnName("ReceiptID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FormPayment).HasMaxLength(250);

                entity.Property(e => e.ProviderId).HasColumnName("ProviderID");

                entity.Property(e => e.Status).HasMaxLength(250);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.CrmReceiptImport)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_CRM_Receipt_Import_CRM_Employee");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.CrmReceiptImport)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("FK_CRM_Receipt_Import_CRM_Provider");
            });

            modelBuilder.Entity<CrmReceiptReturn>(entity =>
            {
                entity.HasKey(e => e.ReceiptId);

                entity.ToTable("CRM_Receipt_Return");

                entity.Property(e => e.ReceiptId).HasColumnName("ReceiptID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DeliveryReceiptId).HasColumnName("DeliveryReceiptID");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FormPayment).HasMaxLength(250);

                entity.Property(e => e.Status).HasMaxLength(250);

                entity.Property(e => e.TotalAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalPaid).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalReduceAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalRemain).HasDefaultValueSql("((0))");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CrmReceiptReturn)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CRM_Receipt_Return_CRM_Customer");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.CrmReceiptReturn)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_CRM_Receipt_Return_CRM_Employee");
            });

            modelBuilder.Entity<CrmRoleMenu>(entity =>
            {
                entity.HasKey(e => new { e.Role, e.MenuId });

                entity.ToTable("CRM_Role_Menu");

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.CrmRoleMenu)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CRM_Role_Menu_CRM_Menu");
            });

            modelBuilder.Entity<CrmTags>(entity =>
            {
                entity.HasKey(e => e.Content);

                entity.ToTable("CRM_Tags");

                entity.Property(e => e.Content)
                    .HasMaxLength(250)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EditedBy).HasMaxLength(250);

                entity.Property(e => e.SeokeyWords)
                    .HasColumnName("SEOKeyWords")
                    .HasMaxLength(250);
            });
        }
    }
}
