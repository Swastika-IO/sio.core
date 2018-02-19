// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Swastika.Cms.Lib.Migrations
{
    public partial class Add_Media : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sioc_media",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false, defaultValueSql: "(N'vi-vn')"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Extension = table.Column<string>(maxLength: 50, nullable: false),
                    FileFolder = table.Column<string>(maxLength: 250, nullable: false),
                    FileName = table.Column<string>(maxLength: 250, nullable: false),
                    FileType = table.Column<string>(maxLength: 50, nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_media", x => new { x.Id, x.Specificulture });
                });

            migrationBuilder.CreateTable(
                name: "sioc_article_media",
                columns: table => new
                {
                    MediaId = table.Column<int>(nullable: false),
                    ArticleId = table.Column<string>(maxLength: 50, nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Position = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_article_media", x => new { x.MediaId, x.ArticleId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_sioc_article_media_sioc_article",
                        columns: x => new { x.ArticleId, x.Specificulture },
                        principalTable: "sioc_article",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sioc_article_media_sioc_media",
                        columns: x => new { x.MediaId, x.Specificulture },
                        principalTable: "sioc_media",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sioc_product_media",
                columns: table => new
                {
                    MediaId = table.Column<int>(nullable: false),
                    ProductId = table.Column<string>(maxLength: 50, nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Position = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_product_media", x => new { x.MediaId, x.ProductId, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_sioc_product_media_sioc_media",
                        columns: x => new { x.MediaId, x.Specificulture },
                        principalTable: "sioc_media",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sioc_product_media_sioc_product",
                        columns: x => new { x.ProductId, x.Specificulture },
                        principalTable: "sioc_product",
                        principalColumns: new[] { "Id", "Specificulture" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_article_media_ArticleId_Specificulture",
                table: "sioc_article_media",
                columns: new[] { "ArticleId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_article_media_MediaId_Specificulture",
                table: "sioc_article_media",
                columns: new[] { "MediaId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_product_media_MediaId_Specificulture",
                table: "sioc_product_media",
                columns: new[] { "MediaId", "Specificulture" });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_product_media_ProductId_Specificulture",
                table: "sioc_product_media",
                columns: new[] { "ProductId", "Specificulture" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sioc_article_media");

            migrationBuilder.DropTable(
                name: "sioc_product_media");

            migrationBuilder.DropTable(
                name: "sioc_media");
        }
    }
}