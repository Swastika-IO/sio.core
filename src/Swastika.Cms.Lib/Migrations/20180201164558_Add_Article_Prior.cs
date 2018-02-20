// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Migrations;

namespace Swastika.Cms.Lib.Migrations
{
    public partial class Add_Article_Prior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Priority",
                table: "sioc_category_article",
                nullable: true,
                defaultValueSql: "((0))",
                oldClrType: typeof(int),
                oldDefaultValueSql: "((0))");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "sioc_article",
                nullable: false,
                defaultValueSql: "((0))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "sioc_article");

            migrationBuilder.AlterColumn<int>(
                name: "Priority",
                table: "sioc_category_article",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(int),
                oldNullable: true,
                oldDefaultValueSql: "((0))");
        }
    }
}