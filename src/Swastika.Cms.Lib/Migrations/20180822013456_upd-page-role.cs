using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Swastika.Cms.Lib.Migrations
{
    public partial class updpagerole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_sioc_portal_page_role",
                table: "sioc_portal_page_role");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "sioc_portal_page_role");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sioc_portal_page_role",
                table: "sioc_portal_page_role",
                columns: new[] { "RoleId", "PageId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_sioc_portal_page_role",
                table: "sioc_portal_page_role");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "sioc_portal_page_role",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_sioc_portal_page_role",
                table: "sioc_portal_page_role",
                column: "Id");
        }
    }
}
