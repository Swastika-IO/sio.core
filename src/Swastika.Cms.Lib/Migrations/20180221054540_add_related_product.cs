using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Swastika.Cms.Lib.Migrations
{
    public partial class add_related_product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "sioc_related_product",
                columns: table => new
                {
                    SourceProductId = table.Column<string>(maxLength: 50, nullable: false),
                    RelatedProductId = table.Column<string>(maxLength: 50, nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_related_product", x => new { x.SourceProductId, x.RelatedProductId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_sioc_related_product_sioc_product1",
                        columns: x => new { x.RelatedProductId, x.Specificulture },
                        principalTable: "sioc_product",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sioc_related_product_sioc_product",
                        columns: x => new { x.SourceProductId, x.Specificulture },
                        principalTable: "sioc_product",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_related_product_RelatedProductId_Specificulture",
                table: "sioc_related_product",
                columns: new[] { "RelatedProductId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_related_product_SourceProductId_Specificulture",
                table: "sioc_related_product",
                columns: new[] { "SourceProductId", "Specificulture" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sioc_related_product");

           
        }
    }
}
