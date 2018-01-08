using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Migrations
{
    public partial class allownullscriptsstylestemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Styles",
                table: "sioc_template",
                type: "ntext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ntext");

            migrationBuilder.AlterColumn<string>(
                name: "Scripts",
                table: "sioc_template",
                type: "ntext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ntext");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Styles",
                table: "sioc_template",
                type: "ntext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "ntext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Scripts",
                table: "sioc_template",
                type: "ntext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "ntext",
                oldNullable: true);
        }
    }
}
