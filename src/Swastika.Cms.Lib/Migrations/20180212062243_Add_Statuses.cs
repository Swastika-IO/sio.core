using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Migrations
{
    public partial class Add_Statuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "sioc_product");

            migrationBuilder.DropColumn(
                name: "IsVisible",
                table: "sioc_product");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "sioc_category");

            migrationBuilder.DropColumn(
                name: "IsVisible",
                table: "sioc_category");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "sioc_article");

            migrationBuilder.DropColumn(
                name: "IsVisible",
                table: "sioc_article");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_theme",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_template",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AlterColumn<int>(
                name: "Priority",
                table: "sioc_product_module",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_product_module",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AlterColumn<int>(
                name: "Priority",
                table: "sioc_product_media",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_product_media",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "sioc_product",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_product",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "sioc_position",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_position",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "sioc_parameter",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_parameter",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_module_product",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_module_data",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "sioc_module_attribute_value",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_module_attribute_value",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_module_attribute_set",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_module_article",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_module",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_media",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "sioc_language",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_language",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AlterColumn<int>(
                name: "Priority",
                table: "sioc_file",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_file",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "sioc_culture",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_culture",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "sioc_copy",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_copy",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "sioc_configuration",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_configuration",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "sioc_comment",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_comment",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_category_product",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_category_position",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_category_module",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_category_category",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_category_article",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_category",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_article_module",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AlterColumn<int>(
                name: "Priority",
                table: "sioc_article_media",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_article_media",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "sioc_article",
                nullable: false,
                defaultValueSql: "((1))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_theme");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_template");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_product_module");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_product_media");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "sioc_product");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_product");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "sioc_position");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_position");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "sioc_parameter");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_parameter");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_module_product");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_module_data");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "sioc_module_attribute_value");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_module_attribute_value");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_module_attribute_set");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_module_article");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_module");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_media");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "sioc_language");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_language");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_file");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "sioc_culture");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_culture");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "sioc_copy");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_copy");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "sioc_configuration");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_configuration");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "sioc_comment");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_comment");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_category_product");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_category_position");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_category_module");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_category_category");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_category_article");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_category");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_article_module");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_article_media");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "sioc_article");

            migrationBuilder.AlterColumn<int>(
                name: "Priority",
                table: "sioc_product_module",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "((0))");

            migrationBuilder.AlterColumn<int>(
                name: "Priority",
                table: "sioc_product_media",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "((0))");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "sioc_product",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVisible",
                table: "sioc_product",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Priority",
                table: "sioc_file",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "((0))");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "sioc_category",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVisible",
                table: "sioc_category",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Priority",
                table: "sioc_article_media",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "((0))");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "sioc_article",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVisible",
                table: "sioc_article",
                nullable: false,
                defaultValue: false);
        }
    }
}
