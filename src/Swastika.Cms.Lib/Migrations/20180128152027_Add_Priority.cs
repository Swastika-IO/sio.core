// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Migrations;

namespace Swastika.Cms.Lib.Migrations
{
    public partial class Add_Priority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "sioc_module_product",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "sioc_module_article",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "sioc_category_product",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "sioc_category_position",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.AlterColumn<int>(
                name: "Priority",
                table: "sioc_category_module",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "sioc_category_category",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "sioc_category_article",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.AlterColumn<int>(
                name: "Priority",
                table: "sioc_article_module",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "sioc_module_product");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "sioc_module_article");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "sioc_category_product");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "sioc_category_position");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "sioc_category_category");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "sioc_category_article");

            migrationBuilder.AlterColumn<int>(
                name: "Priority",
                table: "sioc_category_module",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "((0))");

            migrationBuilder.AlterColumn<int>(
                name: "Priority",
                table: "sioc_article_module",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "((0))");
        }
    }
}