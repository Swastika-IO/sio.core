using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Migrations
{
    public partial class Add_PageSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PageSize",
                table: "sioc_module",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PageSize",
                table: "sioc_category",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PageSize",
                table: "sioc_module");

            migrationBuilder.DropColumn(
                name: "PageSize",
                table: "sioc_category");
        }
    }
}
