// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Migrations;

namespace Swastika.Cms.Lib.Migrations
{
    public partial class AddLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sioc_language",
                columns: table => new
                {
                    Keyword = table.Column<string>(maxLength: 250, nullable: false),
                    Specificulture = table.Column<string>(maxLength: 10, nullable: false),
                    Category = table.Column<string>(maxLength: 250, nullable: true),
                    DataType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_language", x => new { x.Keyword, x.Specificulture });
                    table.ForeignKey(
                        name: "FK_Sioc_Language_Sioc_Culture",
                        column: x => x.Specificulture,
                        principalTable: "sioc_culture",
                        principalColumn: "Specificulture",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_language_Specificulture",
                table: "sioc_language",
                column: "Specificulture");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sioc_language");
        }
    }
}