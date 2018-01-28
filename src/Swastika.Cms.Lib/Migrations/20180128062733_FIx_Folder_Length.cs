using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Migrations
{
    public partial class FIx_Folder_Length : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FileFolder",
                table: "sioc_template",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FileFolder",
                table: "sioc_file",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FileFolder",
                table: "sioc_template",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "FileFolder",
                table: "sioc_file",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 250);
        }
    }
}
