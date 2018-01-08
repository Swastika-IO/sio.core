using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Migrations
{
    public partial class AddStylesScriptsTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Scripts",
                table: "sioc_template",
                type: "ntext",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Styles",
                table: "sioc_template",
                type: "ntext",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Scripts",
                table: "sioc_template");

            migrationBuilder.DropColumn(
                name: "Styles",
                table: "sioc_template");
        }
    }
}
