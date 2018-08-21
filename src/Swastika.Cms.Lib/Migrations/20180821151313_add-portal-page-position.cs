using Microsoft.EntityFrameworkCore.Migrations;

namespace Swastika.Cms.Lib.Migrations
{
    public partial class addportalpageposition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sioc_portal_page_position",
                columns: table => new
                {
                    PositionId = table.Column<int>(nullable: false),
                    PortalPageId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sioc_portal_page_position", x => new { x.PositionId, x.PortalPageId });
                    table.ForeignKey(
                        name: "FK_TTS_PortalPage_Position_TTS_PortalPage",
                        column: x => x.PortalPageId,
                        principalTable: "sioc_portal_page",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TTS_PortalPage_Position_TTS_Position",
                        column: x => x.PositionId,
                        principalTable: "sioc_position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sioc_portal_page_position_PortalPageId",
                table: "sioc_portal_page_position",
                column: "PortalPageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sioc_portal_page_position");
        }
    }
}
