//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Infrastructure;
//using Microsoft.EntityFrameworkCore.Metadata;
//using Microsoft.EntityFrameworkCore.Migrations;
//using Swastika.Extension.Blog.Infrastructure.Data.Context;

//namespace Swastika.Extension.Blog.Infrastructure.Data.Migrations
//{
//    [DbContext(typeof(SwastikaExtensionBlogContext))]
//    [Migration("20161213130431_Initial")]
//    partial class Initial
//    {
//        protected override void BuildTargetModel(ModelBuilder modelBuilder)
//        {
//            modelBuilder
//                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
//                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//            modelBuilder.Entity("Swastika.Domain.Models.Blog", b =>
//                {
//                    b.Property<Guid>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnName("Id");

//                    b.Property<DateTime>("BirthDate");

//                    b.Property<string>("Email")
//                        .IsRequired()
//                        .HasColumnType("varchar(100)")
//                        .HasMaxLength(11);

//                    b.Property<string>("Name")
//                        .IsRequired()
//                        .HasColumnType("varchar(100)")
//                        .HasMaxLength(100);

//                    b.HasKey("Id");

//                    b.ToTable("Blogs");
//                });
//        }
//    }
//}
