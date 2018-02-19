// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Swastika.Cms.Lib.Migrations
{
    public partial class AddProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sioc_product",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Content = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Excerpt = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsVisible = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 250, nullable: true),
                    Price = table.Column<double>(nullable: false, defaultValueSql: "((0))"),
                    PriceUnit = table.Column<string>(maxLength: 10, nullable: true),
                    SeoDescription = table.Column<string>(maxLength: 4000, nullable: true),
                    SeoKeywords = table.Column<string>(maxLength: 4000, nullable: true),
                    SeoName = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    SeoTitle = table.Column<string>(maxLength: 4000, nullable: true),
                    Source = table.Column<string>(maxLength: 250, nullable: true),
                    Tags = table.Column<string>(maxLength: 500, nullable: true),
                    Template = table.Column<string>(maxLength: 250, nullable: true),
                    Thumbnail = table.Column<string>(maxLength: 250, nullable: true),
                    Title = table.Column<string>(maxLength: 4000, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Views = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_product", x => new { x.Id, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_TTS_Product_TTS_Culture",
                        column: x => x.Specificulture,
                        principalTable: "sioc_culture",
                        principalColumn: "Specificulture",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sioc_category_product",
                columns: table => new
                {
                    ProductId = table.Column<string>(maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_category_product", x => new { x.ProductId, x.CategoryId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_TTS_Category_Product_TTS_Category",
                        columns: x => new { x.CategoryId, x.Specificulture },
                        principalTable: "sioc_category",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TTS_Category_Product_TTS_Product",
                        columns: x => new { x.ProductId, x.Specificulture },
                        principalTable: "sioc_product",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sioc_product_module",
                columns: table => new
                {
                    ModuleId = table.Column<int>(nullable: false),
                    ProductId = table.Column<string>(maxLength: 50, nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Position = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_product_module", x => new { x.ModuleId, x.ProductId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_TTS_Product_Module_TTS_Module1",
                        columns: x => new { x.ModuleId, x.Specificulture },
                        principalTable: "sioc_module",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TTS_Product_Module_TTS_Product",
                        columns: x => new { x.ProductId, x.Specificulture },
                        principalTable: "sioc_product",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_category_product_CategoryId_Specificulture",
                table: "sioc_category_product",
                columns: new[] { "CategoryId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_category_product_ProductId_Specificulture",
                table: "sioc_category_product",
                columns: new[] { "ProductId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_product_Specificulture",
                table: "sioc_product",
                column: "Specificulture");

            migrationBuilder.CreateIndex(
                name: "IX_sioc_product_module_ModuleId_Specificulture",
                table: "sioc_product_module",
                columns: new[] { "ModuleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_product_module_ProductId_Specificulture",
                table: "sioc_product_module",
                columns: new[] { "ProductId", "Specificulture" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sioc_category_product");

            migrationBuilder.DropTable(
                name: "sioc_product_module");

            migrationBuilder.DropTable(
                name: "sioc_product");
        }
    }
}