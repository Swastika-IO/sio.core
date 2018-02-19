// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Migrations;

namespace Swastika.Cms.Lib.Migrations
{
    public partial class Add_Nav_Image_Desc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "sioc_product_module",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "sioc_product_module",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "sioc_product_media",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "sioc_product_media",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "sioc_module_product",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "sioc_module_product",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "sioc_module_article",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "sioc_module_article",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "sioc_category_product",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "sioc_category_product",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "sioc_category_module",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "sioc_category_category",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "sioc_category_category",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "sioc_category_article",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "sioc_category_article",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "sioc_article_module",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "sioc_article_module",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "sioc_article_media",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "sioc_article_media",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "sioc_product_module");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "sioc_product_module");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "sioc_product_media");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "sioc_product_media");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "sioc_module_product");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "sioc_module_product");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "sioc_module_article");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "sioc_module_article");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "sioc_category_product");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "sioc_category_product");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "sioc_category_module");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "sioc_category_category");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "sioc_category_category");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "sioc_category_article");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "sioc_category_article");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "sioc_article_module");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "sioc_article_module");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "sioc_article_media");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "sioc_article_media");
        }
    }
}