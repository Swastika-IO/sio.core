// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Migrations;

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