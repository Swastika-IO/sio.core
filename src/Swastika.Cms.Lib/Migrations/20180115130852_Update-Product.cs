using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Migrations
{
    public partial class UpdateProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TTS_Module_Data_TTS_Article_Module",
                table: "sioc_module_data");

            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "sioc_module_data",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "sioc_module_product",
                columns: table => new
                {
                    ProductId = table.Column<string>(maxLength: 50, nullable: false),
                    ModuleId = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_module_product", x => new { x.ProductId, x.ModuleId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_TTS_Module_Product_TTS_Module",
                        columns: x => new { x.ModuleId, x.Specificulture },
                        principalTable: "sioc_module",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TTS_Module_Product_TTS_Product",
                        columns: x => new { x.ProductId, x.Specificulture },
                        principalTable: "sioc_product",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_module_data_ModuleId_ProductId_Specificulture",
                table: "sioc_module_data",
                columns: new[] { "ModuleId", "ProductId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_module_product_ModuleId_Specificulture",
                table: "sioc_module_product",
                columns: new[] { "ModuleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_module_product_ProductId_Specificulture",
                table: "sioc_module_product",
                columns: new[] { "ProductId", "Specificulture" });

            migrationBuilder.AddForeignKey(
                name: "FK_TTS_Module_Data_TTS_Product_Module",
                table: "sioc_module_data",
                columns: new[] { "ModuleId", "ProductId", "Specificulture" },
                principalTable: "sioc_article_module",
                principalColumns: new[] { "ModuleId", "ArticleId", "Specificulture" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TTS_Module_Data_TTS_Product_Module",
                table: "sioc_module_data");

            migrationBuilder.DropTable(
                name: "sioc_module_product");

            migrationBuilder.DropIndex(
                name: "IX_sioc_module_data_ModuleId_ProductId_Specificulture",
                table: "sioc_module_data");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "sioc_module_data");

            migrationBuilder.AddForeignKey(
                name: "FK_TTS_Module_Data_TTS_Article_Module",
                table: "sioc_module_data",
                columns: new[] { "ModuleId", "ArticleId", "Specificulture" },
                principalTable: "sioc_article_module",
                principalColumns: new[] { "ModuleId", "ArticleId", "Specificulture" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
