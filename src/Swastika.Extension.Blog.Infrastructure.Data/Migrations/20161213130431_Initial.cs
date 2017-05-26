//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore.Migrations;

//namespace Swastika.Extension.Blog.Infrastructure.Data.Migrations
//{
//    public partial class Initial : Migration
//    {
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.CreateTable(
//                name: "Blogs",
//                columns: table => new
//                {
//                    Id = table.Column<Guid>(nullable: false),
//                    BirthDate = table.Column<DateTime>(nullable: false),
//                    Email = table.Column<string>(type: "varchar(100)", maxLength: 11, nullable: false),
//                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Blogs", x => x.Id);
//                });
//        }

//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropTable(
//                name: "Blogs");
//        }
//    }
//}
