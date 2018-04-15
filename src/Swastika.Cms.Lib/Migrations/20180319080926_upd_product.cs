using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Migrations
{
    public partial class upd_product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "sioc_product",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "DealPrice",
                table: "sioc_product",
                nullable: true,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "sioc_product",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<double>(
                name: "ImportPrice",
                table: "sioc_product",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<string>(
                name: "Material",
                table: "sioc_product",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NormalPrice",
                table: "sioc_product",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<int>(
                name: "PackageCount",
                table: "sioc_product",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "sioc_product",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalSaled",
                table: "sioc_product",
                nullable: false,
                defaultValueSql: "((0))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "sioc_product");

            migrationBuilder.DropColumn(
                name: "DealPrice",
                table: "sioc_product");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "sioc_product");

            migrationBuilder.DropColumn(
                name: "ImportPrice",
                table: "sioc_product");

            migrationBuilder.DropColumn(
                name: "Material",
                table: "sioc_product");

            migrationBuilder.DropColumn(
                name: "NormalPrice",
                table: "sioc_product");

            migrationBuilder.DropColumn(
                name: "PackageCount",
                table: "sioc_product");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "sioc_product");

            migrationBuilder.DropColumn(
                name: "TotalSaled",
                table: "sioc_product");
        }
    }
}
