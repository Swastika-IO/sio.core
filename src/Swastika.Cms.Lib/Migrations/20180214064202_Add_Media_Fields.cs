using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Migrations
{
    public partial class Add_Media_Fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "sioc_media",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FileSize",
                table: "sioc_media",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "sioc_media",
                maxLength: 4000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "sioc_media");

            migrationBuilder.DropColumn(
                name: "FileSize",
                table: "sioc_media");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "sioc_media");
        }
    }
}
