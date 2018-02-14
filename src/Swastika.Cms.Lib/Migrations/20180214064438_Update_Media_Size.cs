using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Migrations
{
    public partial class Update_Media_Size : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "sioc_media",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(int),
                oldDefaultValueSql: "((0))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FileSize",
                table: "sioc_media",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(long),
                oldDefaultValueSql: "((0))");
        }
    }
}
